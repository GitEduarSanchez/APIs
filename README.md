# api
Api con .NET

GET
https://poliedroapi.azurewebsites.net/api/producto

GET("{id}")
https://poliedroapi.azurewebsites.net/api/producto/1

POST
https://poliedroapi.azurewebsites.net/api/producto
{
  "id": 0,
  "nombre": "Nombre",
  "descripcion": "descripcion",
  "categoriaid": 1,
  "img": "img.png"
}
// categoriaid 1 : software
// categoriaid 2 : hardware

PUT("{id}")
https://poliedroapi.azurewebsites.net/api/producto/1
{
  "id": 0,
  "nombre": "Nombre",
  "descripcion": "descripcion",
  "categoriaid": 1,
  "img": "img.png"
}
// categoriaid 1 : software
// categoriaid 2 : hardware

DELETE("{id}")
https://poliedroapi.azurewebsites.net/api/producto/1

