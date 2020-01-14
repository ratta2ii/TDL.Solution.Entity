using System.Collections.Generic; 
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
    public class Item
    {
        private string description;
        private int Id;

        public Item()
        {

        }

        public Item(string description)
        {
            this.description = description;  
        }
        public Item(string description, int id)
        {
            this.description = description;
            this.Id = id;
        }


    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = (this.Id == newItem.Id);
        bool descriptionEquality = (this.getDescription() == newItem.getDescription());
        return (idEquality && descriptionEquality);
      }
    }

        public string getDescription()
        {
            return this.description;
        }

        public void setDescription(string new_des)
        {
            this.description = new_des;
        }

        public static List<Item> getAllItems()
        {
            List<Item> allItems = new List<Item> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM items;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int itemId = rdr.GetInt32(0);
                string itemDescription = rdr.GetString(1);
                Item newItem = new Item(itemDescription, itemId);
                allItems.Add(newItem);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allItems;
        }

        public static void clearAllItems()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM items;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
        }

        public string toString()
        {
            return "Item description is "+this.description;
        }

        public int getId()
        {
            return this.Id;
        }

        public void setId(int newId)
        {
            this.Id = newId;
        }

        // public static Item Find(int searchId)
        // {
        //     return null;
        // }

        public static Item Find(int id)
        {
            // We open a connection.
            MySqlConnection conn = DB.Connection();
            conn.Open();

            // We create MySqlCommand object and add a query to its CommandText property. We always need to do this to make a SQL query.
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `items` WHERE id = @thisId;";

            // We have to use parameter placeholders (@thisId) and a `MySqlParameter` object to prevent SQL injection attacks. This is only necessary when we are passing parameters into a query. We also did this with our Save() method.
            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            // We use the ExecuteReader() method because our query will be returning results and we need this method to read these results. This is in contrast to the ExecuteNonQuery() method, which we use for SQL commands that don't return results like our Save() method.
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int itemId = 0;
            string itemDescription = "";
            while (rdr.Read())
            {
                itemId = rdr.GetInt32(0);
                itemDescription = rdr.GetString(1);
            }
            Item foundItem= new Item(itemDescription, itemId);

            // We close the connection.
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundItem;
        }
         public void Save()
        {
              MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;

                // Begin new code

                cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";
                MySqlParameter description = new MySqlParameter();
                description.ParameterName = "@ItemDescription";
                description.Value = this.getDescription();
                cmd.Parameters.Add(description);    
                cmd.ExecuteNonQuery();
                setId((int) cmd.LastInsertedId);

                // End new code

                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
        }


    }
}








//  namespace ToDoListItem.Models
// {
//     public class Item
//     {
//         private string description;

//         public Item(string description)
//         {
//             this.description = description;
            
            
//         }
//         public string getDescription()
//         {
//             return this.description;
//         }

//         public void setDescription(string new_des)
//         {
//             this.description = new_des;
//         }

//         public string toString()
//         {
//             return "Item is  "+this.description;
//         }


//     }
// }