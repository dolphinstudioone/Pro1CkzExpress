using System;

using NewsForBuh.Models;

namespace NewsForBuh.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public itemNews Item { get; set; }
        public ItemDetailViewModel(itemNews item = null)
        {
            Title = item?.Idbx;
            Item = item;
        }
    }
}
