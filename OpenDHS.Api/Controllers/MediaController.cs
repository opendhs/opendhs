using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using OpenDHS.Shared;

namespace OpenDHS.Api.Controllers
{
    [Route("api/media")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _uploadService;
        private readonly ILogger<MediaController> _logger;

        public MediaController(IMediaService uploadService, ILogger<MediaController> logger)
        {
            _uploadService = uploadService;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> PostSingleFile([FromForm] MediaUploadModel fileModel)
        {
            if (fileModel == null)
            {
                return BadRequest();

            }

            if (fileModel.FileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                var result =  await _uploadService.PostFileAsync(fileModel.FileDetails, fileModel.IsPublic);
                var fileExtension = Path.GetExtension(result.FileName);
                if (result.IsPublic)
                {

                    return Ok(new MediaModel { 
                        Uuid = result.Uuid,
                        FileName = result.FileName ?? "",
                        FileUrl = @"/media/" + result.Uuid.ToString() + fileExtension,
                        IsPublic = result.IsPublic
                    });

                }
                else {
                     return Ok(new MediaModel
                    {
                        Uuid = result.Uuid,
                        FileName = result.FileName ?? "",
                        IsPublic = result.IsPublic
                    });

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // [HttpPost("uploads")]
        //public async Task<ActionResult> PostMultipleFile([FromForm] List<MediaUploadModel> fileDetails)
        //{
        //    if (fileDetails == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        await _uploadService.PostMultiFileAsync(fileDetails);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpGet("download/{uuid}")]
        public async Task<ActionResult> DownloadFile(string uuid)
        {
            try
            {
                var uuidParsed = Guid.Parse(uuid);
                var media = await _uploadService.DownloadFileById(uuidParsed);
                if(media == null || string.IsNullOrEmpty(media.FileName) || media.FileData == null) { return BadRequest(); }

                var contentTypePrivider = new FileExtensionContentTypeProvider();
                if (contentTypePrivider.TryGetContentType(media.FileName, out string contentType))
                {
                    return File(media.FileData, contentType, media.FileName);
                }
                return File(media.FileData, "application/octet-stream", media.FileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
