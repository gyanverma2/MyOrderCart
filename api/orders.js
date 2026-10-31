const http = require('http');

function sameTotal(a, b) {
  return a === b;
}

http.createServer((req, res) => {
  res.setHeader('Access-Control-Allow-Origin', 'https://shop.example.com');
  res.end(String(sameTotal(1, 1)));
}).listen(8080);
