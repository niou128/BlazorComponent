using BlazorDataGrid.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace BlazorDatagridTests
{
    public class DisplayHelperTests
    {
        [Fact(DisplayName = "DisplayDate - object null")]
        [Trait("Category", "DisplayDate")]
        public void DisplayDate_If_dt_is_null_return_string_empty()
        {
            var result = DisplayHelper.DisplayDate(null, "");

            Assert.Empty(result);
        }

        [Fact(DisplayName = "DisplayDate - if format null convert date to invariant culture")]
        [Trait("Category", "DisplayDate")]
        public void DisplayDate_If_dt_is_a_date_and_format_is_null_convert_date_as_invariant_culture()
        {
            const string expectedResult = "06/15/1993 00:00:00";

            DateTime dt = new DateTime(1993, 6, 15);
            var result = DisplayHelper.DisplayDate(dt, null);

            Assert.Equal(expectedResult, result);
        }

        [Fact(DisplayName = "DisplayDate - If wrong format date return string empty")]
        [Trait("Category", "DisplayDate")]
        public void DisplayDate_If_wrong_date_format_return_string_empty()
        {
            const string date = "bad format";
            var result = DisplayHelper.DisplayDate(date);

            Assert.Empty(result);
        }

        public class NotADate
        {
            public int Index { get; set; }
            public string Label { get; set; }
        }

        [Fact(DisplayName = "DisplayDate - If object not a date return string empty")]
        [Trait("Category", "DisplayDate")]
        public void DisplayDate_If_object_not_a_date_return_string_empty()
        {
            NotADate date = new NotADate
            {
                Index = 1,
                Label = "princesse"
            };

            var result = DisplayHelper.DisplayDate(date, null);

            Assert.Empty(result);
        }

        public static IEnumerable<object[]> DataCulture =>
        new List<object[]>
        {
            new object[] { "fr-FR", "15/06/1993 00:00:00" },
            new object[] { "en-GB", "15/06/1993 00:00:00" },
            new object[] { "en-US", "6/15/1993 12:00:00 AM" },
            new object[] { "de-DE", "15.06.1993 00:00:00" }
        };

        [Theory(DisplayName = "DisplayDate - If cultureinfo not null display date in culture info")]
        [Trait("Category", "DisplayDate")]
        [MemberData(nameof(DataCulture))]
        public void DisplayDate_If_culture_info_not_null_display_date_in_culture(string culture, string expectedDate)
        {
            DateTime dt = new DateTime(1993, 6, 15);
            var result = DisplayHelper.DisplayDate(dt, null, culture);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        [Trait("Category", "DisplayDate")]
        public void DisplayDate_Convert_string_to_date()
        {
            const string expectedResult = "1/6/1993 12:00:00 AM";
            string dt = "01-06-1993";
            var result = DisplayHelper.DisplayDate(dt, null, "en-US");

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> StringDate =>
        new List<object[]>
        {
            new object[] { "fr-FR", "15/06/1993" },
            new object[] { "en-GB", "15/06/1993" },
            new object[] { "de-DE", "15.06.1993" },
            new object[] { "en-US", "06/15/1993" },
        };

        [Theory(DisplayName = "DisplayDate - Convert string to culture date")]
        [Trait("Category", "DisplayDate")]
        [MemberData(nameof(StringDate))]
        public void DisplayDate_Convert_string_to_culture_date(string culture, string inputDate)
        {
            const string expectedResult = "15/06/1993";
            var result = DisplayHelper.DisplayDate(inputDate, "dd/MM/yyyy", culture);

            Assert.Equal(expectedResult, result);
        }

    }
}
