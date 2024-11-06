using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Offerly.Api.Responses;
using Offerly.Domain.Models;
using System.Text.Json;

namespace Offerly.Components.Pages.Offers
{
    public partial class Offers
    {
        [Inject]
        public required IHttpClientFactory ClientFactory { get; set; }

        private IEnumerable<Offer>? offers = [];
        private bool getOffersError;
        private bool shouldRender;

        protected override bool ShouldRender() => shouldRender;

        protected override async Task OnInitializedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7265/offers");
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            //request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var apiResponse = await JsonSerializer.DeserializeAsync<ActionResult<GetOffersApiResponse>>(responseStream);
                offers = apiResponse.Value.Offers;
            }
            else
            {
                getOffersError = true;
            }

            shouldRender = true;
        }

        //[Inject]
        //public required OfferApiClient OffersApiClient { get; set; }

        //private IQueryable<Offer>? _offers;

        //private IDialogReference? _dialog;

        //protected override async Task OnInitializedAsync()
        //{
        //    await LoadOffers();
        //}

        //private async Task LoadOffers()
        //{
        //    _offers = (IQueryable<Offer>?)(await OffersApiClient.GetAllOffers()).Offers;
        //}

        //private async Task OnAddNewPizzaClick()
        //{
        //    var panelTitle = $"Add a pizza";
        //    var result = await ShowPanel(panelTitle, new PizzaEntity() { Name = "New Pizza" });
        //    if (result.Cancelled)
        //    {
        //        return;
        //    }
        //    var entity = result.Data as PizzaEntity;
        //    ShowProgressToast(nameof(OnAddNewPizzaClick), "Pizza", entity!.Name);
        //    _ = await Service.AddPizzaAsync(entity!);
        //    CloseProgressToast(nameof(OnAddNewPizzaClick));
        //    ShowSuccessToast("Pizza", entity!.Name);
        //    await LoadOffers();
        //}

        //private async Task OnEditPizzaClick(PizzaEntity pizza)
        //{
        //    var panelTitle = $"Edit pizza";
        //    var result = await ShowPanel(panelTitle, pizza, false);
        //    if (result.Cancelled)
        //    {
        //        return;
        //    }
        //    var entity = result.Data as PizzaEntity;
        //    ShowProgressToast(nameof(OnEditPizzaClick), "Pizza", entity!.Name, Operation.Update);
        //    await Service.UpdatePizzaAsync(entity!);
        //    CloseProgressToast(nameof(OnEditPizzaClick));
        //    ShowSuccessToast("Pizza", entity!.Name, Operation.Update);
        //    await LoadOffers();
        //}

        //private async Task OnDeletePizzaClick(PizzaEntity entity)
        //{
        //    var confirm = await ShowConfirmationDialogAsync("Delete Pizza", $"Are you sure you want to delete {entity.Name}?");
        //    if (confirm.Cancelled)
        //    {
        //        return;
        //    }
        //    ShowProgressToast(nameof(OnDeletePizzaClick), "Pizza", entity.Name, Operation.Delete);
        //    await Service.DeletePizzaAsync(entity);
        //    CloseProgressToast(nameof(OnDeletePizzaClick));
        //    ShowSuccessToast("Pizza", entity.Name, Operation.Delete);
        //    await LoadOffers();
        //}

        //private async Task<DialogResult> ShowPanel(string title, Offer offer, bool isAdd = true)
        //{
        //    var primaryActionText = isAdd ? "Add" : "Save changes";
        //    var dialogParameter = new DialogParameters<Offer>()
        //    {
        //        Content = offer,
        //        Alignment = HorizontalAlignment.Right,
        //        Title = title,
        //        PrimaryAction = primaryActionText,
        //        Width = "500px",
        //        PreventDismissOnOverlayClick = true,
        //    };
        //    _dialog = await DialogService.ShowPanelAsync<PizzaUpsertPanel>(offer, dialogParameter);
        //    return await _dialog.Result;
        //}
    }
}