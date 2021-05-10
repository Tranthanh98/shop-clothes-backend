using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopClothes.Test.Services
{
    public class TestDownloadData
    {
        [Fact]
        public async Task DownloadImage()
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] image = await webClient.DownloadDataTaskAsync("http://product.hstatic.net/1000341789/product/mausac_green_dsc_9470_ca015a3ad9974475955c7fc34802b4ad_1024x1024.jpg");

                Assert.True(true);
            }
        }
    }
}
