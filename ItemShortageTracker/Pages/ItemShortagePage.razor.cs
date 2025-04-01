using ItemShortageTracker.Data;
using ItemShortageTracker.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ItemShortageTracker.Pages
{
    public partial class ItemShortagePage
    {
        [Parameter]
        public string CategoryId { get; set; }

        [Inject]
        IItemShortageService ItemShortageService { get; set; }

        public ItemShortageVm ItemShortageVm { get; set; } = new ItemShortageVm();

        private int maxStatus = Enum.GetValues<ShortageStatus>().Length - 1;
        private List<string> statusLabels = new List<string> { "None", "1Week", "1Month", "3Month", "1Year" };

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            if (string.IsNullOrEmpty(CategoryId))
            {
                CategoryId = "1";
            }

            ItemShortageVm.Items = await ItemShortageService.GetAllItems(int.Parse(CategoryId));
            ItemShortageVm.Categories = await ItemShortageService.GetAllCategories();
            await InvokeAsync(StateHasChanged);
        }
        public async Task SaveChanges()
        {
            await ItemShortageService.SaveItem(ItemShortageVm.Items);
        }

        public async Task AddNewItem()
        {
            ItemShortageVm.NewItem.CategoryId = int.Parse(CategoryId);
            await ItemShortageService.AddNewItem(ItemShortageVm.NewItem);
            ItemShortageVm.Items = await ItemShortageService.GetAllItems(int.Parse(CategoryId));
            ItemShortageVm.NewItem = new Item();
            await InvokeAsync(StateHasChanged);
        }
    }
}
