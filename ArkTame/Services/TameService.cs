using System;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArkTame.Services;

public class TameService
{
    private const string FileName = "Tames.json";
    private const string TameListUrl = "https://www.dododex.com/dinosaurs/tamable";
    



    private void ParseTamableList()
    {
        var doc = new HtmlDocument();
        doc.Load("List of Tamable Creatures _ ARK_ Survival Evolved.html");

        var nodes = doc.DocumentNode.SelectNodes("//h2");
        var node = nodes.FirstOrDefault(htmlNode => htmlNode.InnerText.StartsWith("Tamable"));

        if (node == null)
        {
            return;
        }

        var lis = node.SelectNodes(".//li");


        var result = new List<TameInfo>(lis.Count);
        foreach (var li in lis)
        {
            var name = li.SelectSingleNode(".//div[@class='ccLabel']")?.InnerText;
            if (name == null)
            {
                continue;
            }

            var image = li.SelectSingleNode(".//div[@class='ccImage']/img")?.Attributes["src"]?.Value;
            if (image != null)
            {
                image = $"https://www.dododex.com{image}";
            }
            result.Add(new TameInfo(name, image));
        }

        var json = JsonConvert.SerializeObject(result);
        File.WriteAllText("Tames.json", json);
    }




    public IReadOnlyList<TameInfo>? GetTameInfosFromFile()
    {
        try
        {
            var json = File.ReadAllText(FileName);
            return JsonConvert.DeserializeObject<List<TameInfo>>(json);
        }
        catch
        {
            return null;
        }
    }
}