using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace Assignment4Part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayQueryResults();
        }

        public void DisplayQueryResults()
        {
            BooksEntities books = new BooksEntities();
            var query1 = from title in books.Titles.Include(t => t.Authors)
                         orderby title.Title1
                         select new { titleText = title.Title1, authors = title.Authors };
            QueryListBox.Items.Add("Titles and Authors:");
            foreach (var q in query1)
            {
                List<Author> aList = q.authors.ToList();
                foreach (Author a in q.authors)
                {
                    QueryListBox.Items.Add(String.Format("{0}\t{1} {2}", q.titleText, a.FirstName, a.LastName));
                }
            }
            QueryListBox.Items.Add("\nAuthors and Titles with authors sorted for each title:");
            var query2 = from title in books.Titles.Include(a => a.Authors)
                         orderby title.Title1
                         select new
                         {
                             titleText = title.Title1,
                             authorNameText = (from author in title.Authors orderby author.LastName, author.FirstName select new { fnText = author.FirstName, lnText = author.LastName })
                         };
            foreach (var q in query2)
            {
                foreach (var a in q.authorNameText)
                {
                    QueryListBox.Items.Add(String.Format("{0}\t{1} {2}", q.titleText, a.fnText, a.lnText));
                }
            }

            QueryListBox.Items.Add("\nTitles grouped by Author:");
            var query3 = from title in books.Titles.Include(a => a.Authors)
                         orderby title.Title1
                         select new
                         {
                             titleText = title.Title1,
                             authorNameText = (from author in title.Authors orderby author.LastName, author.FirstName select new { fnText = author.FirstName, lnText = author.LastName })
                         };
            foreach (var q in query3)
            {
                QueryListBox.Items.Add(q.titleText + ":");
                foreach (var a in q.authorNameText)
                {
                    QueryListBox.Items.Add(String.Format(" {0} {1}", a.fnText, a.lnText));
                }
            }
        }
    }
}
