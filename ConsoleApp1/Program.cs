// See https://aka.ms/new-console-template for more information

using Model;

Repository rep  =new Repository();
Assets dat = await rep.GetAssetAsync("bitcoin");
Console.WriteLine(dat.data.Id);