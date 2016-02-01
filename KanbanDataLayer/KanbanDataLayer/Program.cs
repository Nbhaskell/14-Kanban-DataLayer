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
                bool stop = false;
                while (!stop)
                { 
                    Console.WriteLine("Please choose an option. \n 1. Show all data \n 2. Add new list \n 3. Delete all data \n 4. Quit");
                    int switchCase = int.Parse(Console.ReadLine());
                    switch (switchCase)
                    {
                        case 1:
                            foreach (var list in db.Lists)
                            {
                                Console.WriteLine(list.Name);
                                foreach (var card in list.Cards)
                                {
                                    Console.WriteLine("\t" + card.Text);
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter a new list: ");
                            string newListText = Console.ReadLine();
                            List newList = new List();
                            newList.Name = newListText;
                            newList.CreatedDate = DateTime.Now;
                            db.Lists.Add(newList);
                            db.SaveChanges();

                            Console.WriteLine("Please choose an option. \n 1. Enter a new card. \n 2. Quit");
                            string needCard = Console.ReadLine();
                            if (needCard == "1")
                            {
                                Console.WriteLine("Enter a new Card: ");
                                string newCardText = Console.ReadLine();
                                Card newCard = new Card();
                                newCard.Text = newCardText;
                                newCard.CreatedDate = DateTime.Now;
                                newList.Cards.Add(newCard);
                                db.SaveChanges();
                            }
                            break;
                        case 3:
                            db.Cards.RemoveRange(db.Cards);
                            db.Lists.RemoveRange(db.Lists);
                            db.SaveChanges();
                            break;
                        default:
                            stop = true;
                            break;
                    }
                }
            } 
            Console.ReadLine();
        }
    }
}
