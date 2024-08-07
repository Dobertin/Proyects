﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Facturacion.Models;

namespace Facturacion.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoDatabase Database => _database;
        public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
        public IMongoCollection<Producto> Productos => _database.GetCollection<Producto>("Productos");
        public IMongoCollection<ListaPrecio> ListasPrecios => _database.GetCollection<ListaPrecio>("ListasDePrecios");
        public IMongoCollection<Promocion> Promociones => _database.GetCollection<Promocion>("Promociones");
        public IMongoCollection<TipoImpuesto> TiposImpuestos => _database.GetCollection<TipoImpuesto>("TiposDeImpuestos");
        public IMongoCollection<TipoPago> TiposPagos => _database.GetCollection<TipoPago>("TiposDePago");
        public IMongoCollection<Factura> Facturas => _database.GetCollection<Factura>("Facturas");
        public IMongoCollection<Counter> Counters => _database.GetCollection<Counter>("Counters");
    }
}
