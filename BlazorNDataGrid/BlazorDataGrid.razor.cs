using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlazorDataGrid
{
    public partial class BlazorDataGrid<TableItem>
    {
        #region Parameters
        [Parameter]
        public bool ShowPageSelector { get; set; } = true;

        [Parameter]
        public Dictionary<string, int> PageSelector { get; set; }

        [Parameter]
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                curPage = 1;
                startPage = 1;
                if (value == 0)
                {
                    ItemList = Items;
                    totalPages = 1;
                    pagerSize = 1;
                }
                else
                {
                    ItemList = Items.Skip((curPage - 1) * PageSize).Take(PageSize);
                    totalPages = (int)Math.Ceiling(Items.Count() / (decimal)PageSize);
                    pagerSize = 5;
                }

                StateHasChanged();
                UpdateList(curPage);
                SetPagerSize("filtre");
            }
        }

        [Parameter]
        public RenderFragment BlazorDataGridColumn { get; set; }

        //[Parameter]
        //public RenderFragment<TableItem> GridRow { get; set; }

        [Parameter]
        public RenderFragment GridRow { get; set; }

        private IEnumerable<TableItem> _items;
        [Parameter]
        public IEnumerable<TableItem> Items
        {
            get => _items;
            set
            {
                _items = value ?? new List<TableItem>();
                if (!FromFilter)
                {
                    initCount = _items.Count();
                    UpdateTranslationDictionnary();
                }
                FromFilter = false;
            }
        }

        [Parameter]
        public bool ShowTotalResult { get; set; } = false;

        [Parameter]
        public RenderFragment OtherContent { get; set; }

        [Parameter]
        public string TableClass { get; set; } = "table table-striped table-bordered mdl-data-table";

        [Parameter]
        public string TheadClass { get; set; } = "thead-inverse";

        [Parameter]
        public string TbodyClass { get; set; }

        [Parameter]
        public string TableStyle { get; set; }

        [Parameter]
        public string TheadStyle { get; set; }

        [Parameter]
        public string TbodyStyle { get; set; }

        [Parameter]
        public Dictionary<string, string> Translation { get; set; }

        [Parameter]
        public bool Editable { get; set; } = false;

        [Parameter]
        public bool RowSelector
        {
            get => AppState.RowSelector;
            set => AppState.SetRowSelector(value);
        }

        #endregion

        public string Culture(string colunmName)
        {
            var attributValue = AppState.GetAttribut(colunmName, "Culture");

            return (string)attributValue;
        }

        public string Format(string colunmName)
        {
            var attributValue = AppState.GetAttribut(colunmName, "Format");

            return (string)attributValue;
        }

        public bool ReadOnly(string colunmName, string attribut)
        {
            var attributValue = AppState.GetAttribut(colunmName, attribut);
            if (attributValue == null)
            {
                return false;
            }
            else
            {
                try
                {
                    return (bool)attributValue;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string ContentEditableText
        {
            get => null;
            set => ContentItem = value;
        }

        public object ContentTest
        {
            get => ContentTest;
            set => ContentTest = value;
        }

        private string ContentItem { get; set; }

        protected string DisplayLabelError { get; set; } = "display: none";
        protected string LabelError { get; set; }

        private const int defaultPagerSize = 5;
        private int totalPages, curPage, pagerSize, startPage, endPage, initCount;

        private int _pageSize = -1;

        public string CurrentSortColumn = string.Empty;
        public string LastSortedColumn = string.Empty;
        public bool IsSortedAscending;
        public bool ChangeSorting = false;
        public bool FromFilter = false;

        public int ItemPerPage { get; set; }

        protected List<PageSizeStruct> PageSizeList { get; set; }

        public class PageSizeStruct
        {
            public string Label { get; set; }
            public int Value { get; set; }
        }

        public enum Direction
        {
            First,
            Previous,
            Next,
            PreviousSegment,
            NextSegment,
            Last
        }

        #region Translation
        string OriginalPages { get; set; }
        string OriginalTotalResult { get; set; }
        string OriginalTotalResultPlural { get; set; }
        string OriginalFilteredResults { get; set; }
        string OriginalFilteredResultsPlural { get; set; }

        private bool NeedUpdate { get; set; } = false;
        #endregion

        IEnumerable<TableItem> ItemList { get; set; }

        public Dictionary<string, string> FilterDictionary { get; set; }

        public bool LoadingRow { get; set; } = false;

        protected override void OnInitialized()
        {
            pagerSize = defaultPagerSize;
            initCount = Items.Count();
            if (ShowPageSelector)
            {
                if (PageSizeList == null)
                {
                    if (PageSelector != null)
                    {
                        PageSizeList = new List<PageSizeStruct>();
                        foreach (var selector in PageSelector)
                        {
                            PageSizeList.Add(new PageSizeStruct() { Label = selector.Key, Value = selector.Value });
                        }
                    }
                    else
                    {
                        PageSizeList = new List<PageSizeStruct>
                        {
                            new PageSizeStruct() {Label = "5", Value = 5},
                            new PageSizeStruct() {Label = "10", Value = 10},
                            new PageSizeStruct() {Label = "25", Value = 25},
                            new PageSizeStruct() {Label = "50", Value = 50},
                            new PageSizeStruct() {Label = "100", Value = 100},
                            new PageSizeStruct() {Label = "*", Value = 0},
                        };
                    }
                }
                try
                {
                    if (PageSize == -1)
                        PageSize = PageSizeList[0].Value;
                }
                catch (Exception)
                {
                    PageSize = 5;
                }
            }

            curPage = 1;

            AppState.RefreshRequested += RefreshMe;

            FilterDictionary = new Dictionary<string, string>();

            InitTranslationDictionnary();
            NeedUpdate = true;
            UpdateTranslationDictionnary();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                StateHasChanged();
            }
        }

        private void RefreshMe()
        {
            FromFilter = true;
            StateHasChanged();
            curPage = 1;
            UpdateList(curPage);
            SetPagerSize("filtre");
        }

        public void UpdateList(int currentPage)
        {
            LoadData();

            if (PageSize == 0)
            {
                ItemList = Items;
                totalPages = 1;
            }
            else
            {
                ItemList = Items.Skip((currentPage - 1) * PageSize).Take(PageSize);
                totalPages = (int)Math.Ceiling(Items.Count() / (decimal)PageSize);
                if (totalPages == 0)
                {
                    totalPages = 1;
                }
            }
            curPage = currentPage;

            if (NeedUpdate)
            {
                UpdateTranslationDictionnary();
            }
            this.StateHasChanged();
        }

        public void SetPagerSize(string direction)
        {
            if (direction == "forward" && endPage < totalPages)
            {
                startPage = endPage + 1;
                if (endPage + pagerSize < totalPages)
                {
                    endPage = startPage + pagerSize - 1;
                }
                else
                {
                    endPage = totalPages;
                }
                this.StateHasChanged();
            }
            else if (direction == "back" && startPage > 1)
            {
                endPage = startPage - 1;
                startPage -= pagerSize;
            }
            if (direction == "filtre")
            {
                startPage = 1;
                pagerSize = defaultPagerSize;
                if (pagerSize > totalPages)
                {
                    pagerSize = totalPages;
                }
                endPage = pagerSize;
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                }
                this.StateHasChanged();
            }
        }

        public void NavigateToPage(Direction direction)
        {
            switch (direction)
            {
                case Direction.First:
                    break;
                case Direction.Previous:
                    if (curPage > 1 && curPage == startPage)
                    {
                        SetPagerSize("back");
                    }
                    curPage--;
                    break;
                case Direction.Next:
                    if (curPage < totalPages && curPage == endPage)
                    {
                        SetPagerSize("forward");
                    }
                    curPage++;
                    break;
                case Direction.PreviousSegment:
                    SetPagerSize("back");
                    curPage = endPage;
                    break;
                case Direction.NextSegment:
                    SetPagerSize("forward");
                    curPage = startPage;
                    break;
                case Direction.Last:
                    break;
                default:
                    break;
            }
            UpdateList(curPage);
            UpdateTranslationDictionnary();
        }

        private void InitTranslationDictionnary()
        {
            if (Translation is null)
            {
                Translation = new Dictionary<string, string>
                {
                    { "previous", "Prec." },
                    { "next", "Suiv." },
                    { "pages", $"Page {curPage} de {totalPages}" }
                };
                OriginalPages = "Page __curpage__ de __totalpages__";
                Translation.Add("totalresult", $"{Items.Count()} enregistrement");
                Translation.Add("totalresultplural", $"{Items.Count()} enregistrements");
                OriginalTotalResult = "__totalcount__ enregistrement";
                OriginalTotalResultPlural = "__totalcount__ enregistrements";

                Translation.Add("filteredresults", $"{@Items.Count()} résultat sur {@initCount} enregistrements");
                OriginalFilteredResults = "__filteredcount__ résultat sur __totalcount__ enregistrements";
                Translation.Add("filteredresultsplural", $"{@Items.Count()} résultats sur {@initCount} enregistrements");
                OriginalFilteredResultsPlural = "__filteredcount__ résultats sur __totalcount__ enregistrements";

                Translation.Add("selector", "Résultats par page");
                Translation.Add("loading", "Chargement ...");

                Translation.Add("labelError", "Format invalide");
            }
            else
            {
                try
                {
                    if (!Translation.ContainsKey("previous"))
                    {
                        Translation.Add("previous", "Prec.");
                    }
                    if (!Translation.ContainsKey("next"))
                    {
                        Translation.Add("next", "Suiv.");
                    }
                    if (!Translation.ContainsKey("pages"))
                    {
                        Translation.Add("pages", $"Page {curPage} de {totalPages}");
                        OriginalPages = "Page __curpage__ de __totalpages__";
                    }
                    else
                    {
                        OriginalPages = Translation["pages"];
                    }

                    if (!Translation.ContainsKey("totalresult"))
                    {
                        Translation.Add("totalresult", $"{Items.Count()} enregistrement");
                        OriginalTotalResult = "__totalcount__ enregistrement";
                    }
                    else
                    {
                        OriginalTotalResult = Translation["totalresult"];
                    }

                    if (!Translation.ContainsKey("totalresultplural"))
                    {
                        Translation.Add("totalresultplural", $"{Items.Count()} enregistrements");
                        OriginalTotalResultPlural = "__totalcount__ enregistrements";
                    }
                    else
                    {
                        OriginalTotalResultPlural = Translation["totalresultplural"];
                    }

                    if (!Translation.ContainsKey("filteredresults"))
                    {
                        Translation.Add("filteredresults", $"{Items.Count()} résultat sur {initCount} enregistrements");
                        OriginalFilteredResults = "__filteredcount__ résultat sur __totalcount__ enregistrements";
                    }
                    else
                    {
                        OriginalFilteredResults = Translation["filteredresults"];
                    }

                    if (!Translation.ContainsKey("filteredresultsplural"))
                    {
                        Translation.Add("filteredresultsplural", $"{Items.Count()} résultats sur {initCount} enregistrements");
                        OriginalFilteredResultsPlural = "__filteredcount__ résultats sur __totalcount__ enregistrements";
                    }
                    else
                    {
                        OriginalFilteredResultsPlural = Translation["filteredresultsplural"];
                    }

                    if (!Translation.ContainsKey("selector"))
                    {
                        Translation.Add("selector", "Résultats par page : ");
                    }

                    if (!Translation.ContainsKey("loading"))
                    {
                        Translation.Add("loading", "Chargement ...");
                    }

                    if (!Translation.ContainsKey("labelError"))
                    {
                        Translation.Add("labelError", "Format invalide");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void UpdateTranslationDictionnary()
        {
            try
            {
                if (Translation != null)
                {
                    Translation["pages"] = OriginalPages?.Replace("__curpage__", curPage.ToString())
                                                        .Replace("__totalpages__", totalPages.ToString());

                    Translation["totalresult"] = OriginalTotalResult?.Replace("__totalcount__", Items?.Count().ToString());

                    Translation["totalresultplural"] = OriginalTotalResultPlural?.Replace("__totalcount__", Items?.Count().ToString());

                    Translation["filteredresults"] = OriginalFilteredResults?.Replace("__filteredcount__", Items?.Count().ToString())
                                                                  .Replace("__totalcount__", initCount.ToString());

                    Translation["filteredresultsplural"] = OriginalFilteredResultsPlural?.Replace("__filteredcount__", Items?.Count().ToString())
                                                                        .Replace("__totalcount__", initCount.ToString());
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
        }

        private void LoadData()
        {
            LoadingRow = true;
            StateHasChanged();

            if (FilterDictionary != null)
            {
                foreach (var column in FilterDictionary)
                {
                    Items = Items.Where(x => x.GetType().GetProperty(column.Key).GetValue(x, null).ToString().IndexOf(column.Value, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
            }

            if (!string.IsNullOrEmpty(CurrentSortColumn))
            {
                if (!string.Equals(CurrentSortColumn, LastSortedColumn, StringComparison.OrdinalIgnoreCase))
                {
                    Items = Items.OrderBy(x => x.GetType().GetProperty(CurrentSortColumn).GetValue(x, null)).ToList();
                    LastSortedColumn = CurrentSortColumn;
                    IsSortedAscending = true;
                }
                else
                {
                    if (ChangeSorting)
                    {
                        if (IsSortedAscending)
                        {
                            Items = Items.OrderByDescending(x => x.GetType().GetProperty(CurrentSortColumn).GetValue(x, null)).ToList();
                        }
                        else
                        {
                            Items = Items.OrderBy(x => x.GetType().GetProperty(CurrentSortColumn).GetValue(x, null)).ToList();
                        }
                        IsSortedAscending = !IsSortedAscending;
                        ChangeSorting = false;
                    }
                    else
                    {
                        if (IsSortedAscending)
                        {
                            Items = Items.OrderBy(x => x.GetType().GetProperty(CurrentSortColumn).GetValue(x, null)).ToList();
                        }
                        else
                        {
                            Items = Items.OrderByDescending(x => x.GetType().GetProperty(CurrentSortColumn).GetValue(x, null)).ToList();
                        }
                    }
                }
            }

            LoadingRow = false;
            StateHasChanged();
        }

        protected void UpdateList(TableItem item, string name)
        {
            try
            {
                var jasmine = ContentItem;
                var ariel = Items.FirstOrDefault(x => ReferenceEquals(x, item));

                Type type = item.GetType().GetProperty(name).PropertyType;
                try
                {
                    if (type != typeof(string) && string.IsNullOrEmpty(ContentItem))
                    {
                        jasmine = null;
                    }

                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        type = Nullable.GetUnderlyingType(type);
                    }

                    if (!string.IsNullOrEmpty(jasmine))
                    {
                        var elsa = Convert.ChangeType(jasmine, type);
                        ariel.GetType().GetProperty(name).SetValue(ariel, elsa);
                    }
                    else
                    {
                        ariel.GetType().GetProperty(name).SetValue(ariel, jasmine);
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    LabelError = "Le format saisi n'est pas correct";
                    DisplayLabelError = "display: block";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected TableItem GetValue(TableItem obj, string PropertyName)
        {
            var ariel = obj.GetType().GetProperty(PropertyName).GetValue(obj, null);

            return (TableItem)ariel;
        }

    }
}
