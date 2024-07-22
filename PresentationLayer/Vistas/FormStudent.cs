using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using CrossCutingLayer.Dto;
using CrossCutingLayer.Helpers;
using CrossCutingLayer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Vistas
{
    public partial class FormStudent : Form
    {
        private readonly IServiceStudent _service;
        private readonly OpenFileDialog fd;
        private int pageNumber;
        private int pageSize;
        private int totalPages;

        public FormStudent()
        {
            _service = new ServiceStudent();
            fd = new OpenFileDialog();

            pageNumber = 1;
            pageSize = 10;

            InitializeComponent();
            LoadAllStudents();
            DisabledButtonsEditAndDelete();
        }

        private void DisabledButtonsEditAndDelete()
        {
            CustomButton(btnEdit, false);
            CustomButton(btnDelete, false);
        }

        private void EnabledButtonsEditAndDelete()
        {
            CustomButton(btnEdit, true);
            CustomButton(btnDelete, true);
        }

        private void CustomButton(Button btn, bool isEnabled)
        {
            btn.Enabled = isEnabled;
            btn.BackColor = isEnabled
                            ? btn.Name == btnDelete.Name
                                ? Color.Red
                                : Color.Orange
                            : Color.LightGray;
        }

        private void LoadStudentsOnDataGrid(PaginatedList<StudentDto> students)
        {
            dataGridStudents.DataSource = students.Items.Select(x => new
            {
                x.Id,
                x.Name,
                x.LastName,
                x.DNI,
                x.Email,
            }).ToList();
            dataGridStudents.Columns[0].Visible = false;
        }

        private void LoadAllStudents(string filter = null)
        {
            var students = _service.GetAllPaginatedStudents(filter, pageNumber, pageSize);
            totalPages = students.TotalPages;
            LoadStudentsOnDataGrid(students);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtName.Text;
                var lastName = txtLastName.Text;
                var dni = txtDNI.Text;
                var email = txtEmail.Text;
                var photo = ImageToBytes(photoProfile.Image);

                var student = new StudentDto
                {
                    Name = name,
                    LastName = lastName,
                    DNI = dni,
                    Email = email,
                    Photo = photo,
                };

                var response = _service.RegisterStudent(student);
                if (response.IsValid)
                    MessageBox.Show("El estudiante se registró exitosamente!");
                else
                    ShowErrors(response.Errors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadAllStudents();
            }
            
        }

        private void photoProfile_Click(object sender, EventArgs e)
        {
            CargarImagen(photoProfile);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = "Name";
            if (string.IsNullOrEmpty(txtName.Text))
            {
                lblName.ForeColor = Color.LightGray;
            }
            else
            {
                lblName.ForeColor = Color.LightGreen;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.ValidateOnlyLetters(e);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            lblLastName.Text = "LastName";
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                lblLastName.ForeColor = Color.LightGray;
            }
            else
            {
                lblLastName.ForeColor = Color.LightGreen;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.ValidateOnlyLetters(e);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lblEmail.Text = "Email";
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblEmail.ForeColor = Color.LightGray;
            }
            else if (!Validations.ValidateEmail(txtEmail.Text))
            {
                lblEmail.ForeColor = Color.Red;
            }
            else
            {
                lblEmail.ForeColor = Color.LightGreen;
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            lblDNI.Text = "DNI";
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                lblDNI.ForeColor = Color.LightGray;
            }
            else
            {
                lblDNI.ForeColor = Color.LightGreen;
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.ValidateOnlyNumbers(e);
        }

        private void ShowErrors(Dictionary<string, string> errors)
        {
            foreach (var error in errors)
            {
                if (error.Key.Equals("Name"))
                {
                    lblName.Text = error.Value;
                    lblName.ForeColor = Color.Red;
                }

                if (error.Key.Equals("LastName"))
                {
                    lblLastName.Text = error.Value;
                    lblLastName.ForeColor = Color.Red;
                }

                if (error.Key.Equals("DNI"))
                {
                    lblDNI.Text = error.Value;
                    lblDNI.ForeColor = Color.Red;
                }

                if (error.Key.Equals("Email"))
                {
                    lblEmail.Text = error.Value;
                    lblEmail.ForeColor = Color.Red;
                }

                if (error.Key == string.Empty)
                    MessageBox.Show(error.Value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAllStudents(txtSearch.Text);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (pageNumber < totalPages)
            {
                pageNumber++;
                LoadAllStudents();
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                LoadAllStudents();
            }
        }

        private void btnStartPage_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            LoadAllStudents();
        }

        private void btnEndPage_Click(object sender, EventArgs e)
        {
            pageNumber = totalPages;
            LoadAllStudents();
        }

        private void dataGridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridStudents.Rows[e.RowIndex].DataBoundItem;
            var student = FromObjectToStudentDTO(row);
            PrintStudent(student);
        }

        private StudentDto FromObjectToStudentDTO(object obj)
        {
            return new StudentDto
            {
                Id = (int)obj.GetType().GetProperty("Id").GetValue(obj),
                Name = (string)obj.GetType().GetProperty("Name").GetValue(obj),
                LastName = (string)obj.GetType().GetProperty("LastName").GetValue(obj),
                DNI = (string)obj.GetType().GetProperty("DNI").GetValue(obj),
                Email = (string)obj.GetType().GetProperty("Email").GetValue(obj),
            };
        }

        private void PrintStudent(StudentDto student)
        {
            txtName.Text = student.Name;
            txtLastName.Text = student.LastName;
            txtDNI.Text = student.DNI;
            txtEmail.Text = student.Email;
            txtId.Text = student.Id.ToString();

            if (student.Id > 0)
                EnabledButtonsEditAndDelete();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var studentId = int.Parse(txtId.Text);
                var response = _service.DeleteStudent(studentId);
                if (response.IsValid)
                    MessageBox.Show("El estudiante se eliminó exitosamente!");
                else
                    MessageBox.Show(response.Errors.Values.FirstOrDefault(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadAllStudents();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(txtId.Text);
                var photo = ImageToBytes(photoProfile.Image);

                var student = new StudentDto
                {
                    Id = id,
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    DNI = txtDNI.Text,
                    Email = txtEmail.Text,
                    Photo = photo,
                };
                var response = _service.UpdateStudent(student);
                if (response.IsValid)
                    MessageBox.Show("El estudiante se actualizó exitosamente!");
                else
                    MessageBox.Show(response.Errors.Values.FirstOrDefault(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadAllStudents();
            }
        }

        private void CargarImagen(PictureBox pictureBox)
        {
            pictureBox.WaitOnLoad = true;
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp";
            fd.ShowDialog();
            if (fd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = fd.FileName;
            }
        }

        private byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}