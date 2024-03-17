using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyWeightApp
{
    public partial class Form1 : Form
    { 
        private Client client = new Client();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBoxBtn_Click(object sender, EventArgs e)
        {
            IElement elem = new TextBox();
            lblTb.Text = "________________\n|________________|";
            client.AddElement(elem);
        }

        private void ButtonBtn_Click(object sender, EventArgs e)
        {
            IElement elem = new Button();
            lblBtn.Text = "_____\n| Click |";
            client.AddElement(elem);
        }

        private void ImageBtn_Click(object sender, EventArgs e)
        {
            IElement elem = new Image();
            lblImg.Text = "_______\n|            |\n|  o_O   |\n|______|";
            client.AddElement(elem);
        }

        public class Client
        {
            private string str;
            private List<IElement> elements = new List<IElement>(); 

            public void AddElement(IElement element)
            {
                elements.Add(element);
                element.Display();
            }

            public void CheckAll()
            {
                
                foreach (var element in elements)
                {
                    str += element.Info();
                    str += '\n';   
                }
                MessageBox.Show($"Полученные элементы:\n\n{str}");
                str = "";
            }

            public void ClearAll()
            {
                elements.Clear();
            }
        }

        public interface IElement
        {
            void Display();
            string Info();
        }

        public class TextBox : IElement
        {
            public void Display()
            {
                MessageBox.Show("Создан элемент TextBox");
            }
            public string Info()
            {
                return "TextBox";
            }
        }

        public class Button : IElement
        {
          
            public void Display()
            {
                MessageBox.Show("Создан элемент Button");
            }
            public string Info()
            {
                return "Button";
            }
        }

        public class Image : IElement
        {
            public void Display()
            {
                MessageBox.Show("Создан элемент Image");
            }
            public string Info()
            {
                return "Image";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CLearBtn_Click(object sender, EventArgs e)
        {
            lblTb.Text = "";
            lblBtn.Text = "";
            lblImg.Text = "";
            client.ClearAll();
        }

        private void AddAllBtn_Click(object sender, EventArgs e)
        {
            client.CheckAll();
        }
    }
}
