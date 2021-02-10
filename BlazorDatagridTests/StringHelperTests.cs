using BlazorDataGrid.Helpers;
using Xunit;

namespace BlazorDatagridTests
{
    public class StringHelperTests
    {
        #region UrlEncodeHref
        [Fact(DisplayName = "If text is null or empty, return empty string")]
        [Trait("Category", "UrlEncodeHref")]
        public void Test01()
        {
            const string text = null;

            string result = StringHelper.UrlEncodeHref(text);

            Assert.Equal(string.Empty, result);
        }

        [Fact(DisplayName = "If text not contain href, return text")]
        [Trait("Category", "UrlEncodeHref")]
        public void Test02()
        {
            const string text = @"<a class=""m-card-user__name m-link"">{{Name}}</a>";

            string result = StringHelper.UrlEncodeHref(text);

            Assert.Equal(text, result);
        }

        [Theory(DisplayName ="If text contain href, return text with href urlEncode")]
        [Trait("Category", "UrlEncodeHref")]
        [InlineData("<a href='https://1234\\azd' class='m-card-user__name m-link'>{{Name}}</a>", "<a href='https://1234%5Cazd' class='m-card-user__name m-link'>{{Name}}</a>")]
        [InlineData("<a href='https://nullrefexception.com/'>Cool</a>", "<a href='https://nullrefexception.com%2F'>Cool</a>")]
        [InlineData("<a href='http://nullrefexception.com/'>Cool</a>", "<a href='http://nullrefexception.com%2F'>Cool</a>")]
        [InlineData("<a href='nullrefexception.com/'>Cool</a>", "<a href='nullrefexception.com%2F'>Cool</a>")]
        public void Test03(string text, string expected)
        {
            string result = StringHelper.UrlEncodeHref(text);

            Assert.Equal(expected, result, ignoreCase:true);
        }
        #endregion
    }
}
