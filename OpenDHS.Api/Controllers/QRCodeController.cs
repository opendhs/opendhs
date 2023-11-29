using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenDHS.Shared.QRCode;

namespace OpenDHS.Api.Controllers
{
    [Authorize]
    [Route("api/qrcode")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult CreateQrCode(string qrText)
        {
            var qrCodeImage = QRCodeService.GenerateQRCode(qrText);
            return File(QRCodeService.BitmapToBytes(qrCodeImage), "image/jpeg");
        }
        [HttpGet]
        [Route("colored")]
        public IActionResult CreateQrCodeColor(string qrText)
        {
            var qrCodeImage = QRCodeService.GenerateQRCodeColored(qrText);
            return File(QRCodeService.BitmapToBytes(qrCodeImage), "image/jpeg");
        }

    }
}
