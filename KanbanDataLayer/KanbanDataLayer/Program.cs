using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KanbanDataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new KanbanEntities())
            {
                foreach (var list in db.Lists)
                {
                    Console.WriteLine(list.Name);
                    foreach (var card in list.Cards)
                    {
                        Console.WriteLine("\t" + card.Text);
                    }
                }
                Console.WriteLine("Enter a new list: ");
                string newListText = Console.ReadLine();

                List newList = new List();
                newList.Name = newListText;
                newList.CreatedDate = DateTime.Now;

                db.Lists.Add(newList);
                db.SaveChanges();

                Console.WriteLine("Enter a new Card: ");
                string newCardText = Console.ReadLine();

                Card newCard = new Card();
                newCard.Text = newCardText;
                newCard.CreatedDate = DateTime.Now;

                
                newList.Cards.Add(newCard);
                db.SaveChanges();

                db.Cards.RemoveRange(db.Cards);
                db.Lists.RemoveRange(db.Lists);
                db.SaveChanges();

            }
            Console.ReadLine();
        }
    }
}
