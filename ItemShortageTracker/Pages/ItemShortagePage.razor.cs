using ItemShortageTracker.Data;
using ItemShortageTracker.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ItemShortageTracker.Pages
{
    public partial class ItemShortagePage
    {
        [Inject]
        IItemShortageService ItemShortageService { get; set; }

        public ItemShortageVm ItemShortageVm { get; set; } = new ItemShortageVm();

        private int maxStatus = Enum.GetValues<ShortageStatus>().Length - 1;
        private List<string> statusLabels = new List<string> { "None", "1Week", "1Month", "3Month", "1Year" };

        protected override async Task OnInitializedAsync()
        {
            ItemShortageVm.Items = await ItemShortageService.GetAllItems();
            await base.OnInitializedAsync();
        }
        public async Task SaveChanges()
        {
            await ItemShortageService.SaveItem(ItemShortageVm.Items);
        }

        public async Task AddNewItem()
        {
            await ItemShortageService.AddNewItem(ItemShortageVm.NewItem);
            ItemShortageVm.Items = await ItemShortageService.GetAllItems();
            await InvokeAsync(StateHasChanged);
        }
    }
}
