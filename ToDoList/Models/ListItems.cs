// using System.Collections.Generic;
// namespace ToDoListItem.Models
// {
//     public class ListItem
//     {
//         private Item [] list;
//         private int size;
//         public ListItem()
//         {
//             this.list = new Item[100];
//             this.size = 0;
            

//         }

//         public int getSize()
//         {
//             return this.size;
//         }
//         public void addItem(Item new_item)
//         {
//             this.list[size] = new_item;
//             size++;
//         }

//         public Item getItem(int index)
//         {
//             if(index>=0 && index<=this.size)
//             {
//                 return this.list[index];
//             }
//             return null;
//         }

//         public void addItemByIndex(int idx,Item value)
//         {
//             for(int index = this.size; index >=idx+1; index--)
//             {
//                 this.list[index] = this.list[index-1];
//             }
//             this.list[idx] = value;
//             size++;
        
//         }
//         public void removeItem(int idx)
//         {
//             for(int i=idx; i<size-1; i++)
//             {
//                 this.list[i] = this.list[i+1];
//             }
//             size--;
//         }

//         public string toStirng()
//         {
//             string output = "";
//             for(int idx=0; idx<size; idx++)
//             {
//                 output+=this.list[idx].toString()+"\n";
//             }
//             return output;
//         }
//     }
// }