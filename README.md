# Bitly.Net
Bitly API v4 .Net - Shorten URL Bit.ly

#Usage
```
var bitly = new BitlyAPI("YOUR-ACCESS-TOKEN");
string shortURL = await bitly.ShortenAsync(longURL); //Asynchornous
string shortURL2 = bitly.Shorten(longURL); //Synchronous
```
