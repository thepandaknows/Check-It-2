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

            // Point datagridview to the datasource
            toDoListView.DataSource = todoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // clear out text fields
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // load up a past item, extract the title & description into the text fields
            isEditing = true;
            // fill text fields with data from table: select row & column from user, cast to a string
            // ItemArray = column (text or description)
            titleTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextbox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // access the table, delete the selected row (task item)
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
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
                // if existing note, ability to change it: grab input from text boxes and add to corresponding field in table
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextbox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextbox.Text;
            }
            else
            {
                // if brand new note, add text from title & description boxes as a new row (task item)
                todoList.Rows.Add(titleTextbox.Text, descriptionTextbox.Text);
            }
            // clear out all fields have clicking Save
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
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
            } else
            {
                MessageBox.Show("Please slect a task to mark as done.");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // when user picks a date and clicks the save button, due date column will be added to the table
        }
    }
}
