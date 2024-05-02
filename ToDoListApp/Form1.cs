using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            // Create columns
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Priority");
            todoList.Columns.Add("Due Date", typeof(DateTime));

            // Point datagridview to the datasource
            toDoListView.DataSource = todoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // clear out text fields
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
            priorityComboBox.SelectedIndex = -1; // reset the ComboBox selection
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // load up a past item, extract the title & description into the text fields
            isEditing = true;
            // fill text fields with data from table: select row & column from user, cast to a string
            // ItemArray = column (text or description)
            titleTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            // retrieve priority selection from drop-down
            string priority = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[2].ToString();
            priorityComboBox.SelectedItem = priority;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (toDoListView.SelectedRows.Count > 0)
                {
                    // ask for confirmation before deleting
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // access the table, delete the selected row (task item)
                        todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
                    }
                } 
                else
                {
                    // error checking: make sure the user has selected a task for deletion
                    MessageBox.Show("Please select a task to delete.");
                }
            }
            catch (Exception ex)
            { 
                // error checking:
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                // if existing note, ability to change it: grab input from text boxes and drop-down priority combobox and add to corresponding field in table
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextbox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextbox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Priority"] = priorityComboBox.SelectedItem.ToString();
            }
            else
            {
                // if brand new note, add text from title & description boxes as a new row (task item)
                // assign priority level from priority drop-down
                DataRow newRow = todoList.Rows.Add(titleTextbox.Text, descriptionTextbox.Text, priorityComboBox.SelectedItem != null ? priorityComboBox.SelectedItem.ToString() : "");

                // set the due date for the new row
                newRow["Due Date"] = dateTimePicker1.Value;
            }
            // clear out all fields when clicking Save
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
            priorityComboBox.SelectedIndex = -1; // reset the ComboBox selection
            // dateTimePicker will default to today's date
            dateTimePicker1.Value = DateTime.Today;
            isEditing = false;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            // when user selects a task and clicks the Check it! button, the task text will be struck out
            // check if a task is selected
            if (toDoListView.SelectedRows.Count > 0)
            {
                // get the selected row
                DataGridViewRow selectedRow = toDoListView.SelectedRows[0];

                // strike out the task title and description
                selectedRow.Cells["Title"].Style.Font = new Font(toDoListView.Font, FontStyle.Strikeout);
                selectedRow.Cells["Description"].Style.Font = new Font(toDoListView.Font, FontStyle.Strikeout);
                selectedRow.Cells["Priority"].Style.Font = new Font(toDoListView.Font, FontStyle.Strikeout);
            } else
            {
                MessageBox.Show("Please select a task to mark as done.");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // when user picks a date and clicks the save button, due date column will be added to the table
        }

        private void priorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check if an item is selected in the priority combo box
            if (priorityComboBox.SelectedIndex != -1)
            {
                // retrieve the selected priority
                string selectedPriority = priorityComboBox.SelectedItem.ToString();

                // check if a row is selected in the DataGridView
                if (toDoListView.SelectedRows.Count > 0)
                {
                    // get the selected row
                    DataGridViewRow selectedRow = toDoListView.SelectedRows[0];

                    // update the priority column of the selected row with the chosen priority
                    selectedRow.Cells["Priority"].Value = selectedPriority;
                }
                else
                {
                    // ensure the user chooses a priority level
                    MessageBox.Show("Please select a task to assign priority.");
                }
            } else
            {
                MessageBox.Show("Please select a priority.");
            }
        }
    }
}
