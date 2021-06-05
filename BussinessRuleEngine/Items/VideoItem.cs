using System;
using System.Collections.Generic;
using System.Text;
using BussinessRuleEngine.Interfaces;

namespace BussinessRuleEngine.Items
{
    public class VideoItem : IVideoItem, IItemOrder
    {
        public void AddFreeVideo(string nameOfVideo)
        {
            // Add nameOfVideo as free Video 
        }

        public void ExecuteOrder()
        {
            AddFreeVideo("First Aid");
        }
    }
}
