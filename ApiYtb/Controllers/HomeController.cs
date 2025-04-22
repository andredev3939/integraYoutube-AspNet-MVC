using System.Diagnostics;
using ApiYtb.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;

namespace ApiYtb.Controllers
{
    public class HomeController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var videos = await BuscaVideos();
            return View(videos);
        }
        // Requisições assíncronas retornam "tasks". No caso, do tipo lista e seguindo o modelo escolhido 
        private async Task<List<DetalhesVd>> BuscaVideos()
        {
            // Acessa o serviço da API de acordo com os dados fornecidos
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyC8_JlbKd3T-ZtWIaS1mpAkmmQ49Ukt-dY",
                ApplicationName = "YoutubeApiVideo"
            });
            // Tipos de dados a serem retornados, id do canal, ordenar por ordem de lançamento e quantia máxima de resultados
            var searchRequest = youtubeService.Search.List("snippet");
            searchRequest.ChannelId = "UCib793mnUOhWymCh2VJKplQ";
            searchRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            searchRequest.MaxResults = 25;

            var searchResponse = await searchRequest.ExecuteAsync();

            // Dados retornados postos no objeto videoList
            List<DetalhesVd> videoList = searchResponse.Items.Select(item =>
                new DetalhesVd
                {
                    Title = item.Snippet.Title,
                    Description = item.Snippet.Description,
                    ThumbnailUrl = item.Snippet.Thumbnails?.Medium?.Url,
                    Link = $"https://www.youtube.com/watch?v={item.Id.VideoId}",
                    PublishedAt = item.Snippet.PublishedAt
                }).OrderByDescending(video => video.PublishedAt)
                .ToList();
            
            return videoList;

            }        
    }
}
