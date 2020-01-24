using System;
using System.Collections.Generic;
using System.Text;

using ASSE.Models;

using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;


namespace ASSE.Controls
{
    public class FirebaseHelper
    {

        FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-bc48d.firebaseio.com/");
        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  Uid = item.Object.Uid,
                  Ugrupo = item.Object.Ugrupo,
                  email = item.Object.email,
                  password = item.Object.password,
                  Uarea = item.Object.Uarea,
                  Status = item.Object.Status,
                  FechaIngreso = item.Object.FechaIngreso

              }).ToList();
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Select(item => new Producto
              {

                  Pid = item.Object.Pid,
                  Pnombre = item.Object.Pnombre,
                  Provedor = item.Object.Provedor,
                  Categoria = item.Object.Categoria,
                  Precio = item.Object.Precio,
                  Pstockid = item.Object.Pstockid,
                  defectuoso = item.Object.defectuoso,
                  evaluado = item.Object.evaluado,
                 

              }).ToList();
        }

        public async Task<List<Stok>> GetAllStoks()
        {
            return (await firebase
              .Child("Stock")
              .OnceAsync<Stok>()).Select(item => new Stok
              {
                  Sid = item.Object.Sid,
                  Stipo = item.Object.Stipo,
                  StockAct = item.Object.StockAct,
                  StockMax = item.Object.StockMax,
                  StockMin = item.Object.StockMin



              }).ToList();
        }

        public async Task<List<Especificacion>> GetAllEspecificaciones()
        {
            return (await firebase
              .Child("Especificaciones")
              .OnceAsync<Especificacion>()).Select(item => new Especificacion
              {
                  Eid = item.Object.Eid,
                  Enombre = item.Object.Enombre,
                  EDescripcion = item.Object.EDescripcion,
                  Eselec = item.Object.Eselec


              }).ToList();
        }

        public async Task<List<EspecificacionesP>> GetAllEspecificacionesP()
        {
            return (await firebase
              .Child("EspecificacionesP")
              .OnceAsync<EspecificacionesP>()).Select(item => new EspecificacionesP
              {
                  Pid = item.Object.Pid,
                  email = item.Object.email,
                  Eid = item.Object.Eid,
                  Enombre = item.Object.Enombre,
                  EDescripcion = item.Object.EDescripcion,
                  Eselec = item.Object.Eselec


              }).ToList();
        }

        public async Task AddUsuario(string Uid, string email, string password, string Ugrupo, string FechaIngreso, string Uarea)
        {

            await firebase
              .Child("Usuarios")
              .PostAsync(new Usuario() { Uid = Uid, email = email, password = password, Ugrupo = Ugrupo, FechaIngreso = FechaIngreso, Uarea = Uarea });
        }
        public async Task AddProducto(string Pid, string Categoria, string Pnombre, double Precio, string Provedor, string Pstockid)
        {
            var allProductos = await GetAllProductos();
            if (allProductos.Count == 0)
            {
                await firebase
                  .Child("Productos")
                  .PostAsync(new Producto() { Pid = Pid, Categoria = Categoria, Pnombre = Pnombre, Precio = Precio, Provedor = Provedor, Pstockid = Pstockid });
            }
            else
            {
                await firebase
                 .Child("Productos")
                 .PostAsync(new Producto() { Pid = Pid, Categoria = Categoria, Pnombre = Pnombre, Precio = Precio, Provedor = Provedor, Pstockid = Pstockid });
            }
        }
        public async Task AddEspecificacion(string Pid, string email, string Eid, string Enombre, string EDescripcion, bool Eselec)
        {
            
 
                await firebase
                  .Child("EspecificacionesP")
                  .PostAsync(new EspecificacionesP() { Pid =Pid , email=email,Eid=Eid,Enombre=Enombre,EDescripcion=EDescripcion,Eselec=Eselec});
            
        
        }

        public async Task<Usuario> GetUsuarioSecion(string name, string password)
        {
            var allUsuarios = await GetAllUsuarios();
            await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>();
            return allUsuarios.Where(a => a.email == name && a.password == password).FirstOrDefault();
        }

        public async Task<List<Producto>> GetProductoAleatorio()
        {
            var r = new Random();
            var ProductosA = await GetAllProductos();
            await firebase
              .Child("Productos")
              .OnceAsync<Producto>();
            return ProductosA.OrderBy(x => r.Next()).ToList();
        }

        public async Task<EspecificacionesP> GetEspsid(string Pid)
        {
            var allProductos = await GetAllEspecificacionesP();
            await firebase
              .Child("EspecificacionesP")
              .OnceAsync<EspecificacionesP>();
            return allProductos.Where(a => a.Pid == Pid).FirstOrDefault();
        }
        public async Task<EspecificacionesP> GetEspsidE(string Eid,string Pid)
        {
            var allProductos = await GetAllEspecificacionesP();
            await firebase
              .Child("EspecificacionesP")
              .OnceAsync<EspecificacionesP>();
            return allProductos.Where(a => a.Eid == Eid && a.Pid==Pid).FirstOrDefault();
        }
        public async Task<EspecificacionesP> GetEspsid(string Pid,string Eid)
        {
            var allProductos = await GetAllEspecificacionesP();
            await firebase
              .Child("EspecificacionesP")
              .OnceAsync<EspecificacionesP>();
            return allProductos.Where(a => a.Pid == Pid && a.Eid==Eid).FirstOrDefault();

        }
        public async Task<List<EspecificacionesP>> GetEspsidC(string Pid)
        {
            var allProductos = await GetAllEspecificacionesP();
            await firebase
              .Child("EspecificacionesP")
              .OnceAsync<EspecificacionesP>();
            return allProductos.Where(a => a.Pid == Pid ).ToList();

        }


        public async Task<Usuario> GetUsuario(string Uid)
        {
            var allUsuarios = await GetAllUsuarios();
            await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>();
            return allUsuarios.Where(a => a.Uid == Uid).FirstOrDefault();
        }
        public async Task<Producto> GetProducto(string Pid)
        {
            var allProductos = await GetAllProductos();
            await firebase
              .Child("Productos")
              .OnceAsync<Producto>();
            
            return allProductos.Where(a => a.Pid == Pid).FirstOrDefault();
            
        }
        public async Task<Producto> GetProductoid(string Pid)
        {
            var allProductos= await GetAllProductos();
            await firebase
              .Child("Productos")
              .OnceAsync<Producto>();
            return allProductos.Where(a => a.Pid == Pid).FirstOrDefault();
        }
        
        public async Task<Usuario> GetUsuarioemail(string email)
        {
            var allUsuarios = await GetAllUsuarios();
            await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>();
            return allUsuarios.Where(a => a.email == email).FirstOrDefault();
        }

        public async Task<Stok> GetStockid(string Sid)
        {
            var allStock = await GetAllStoks();
            await firebase
              .Child("Stock")
              .OnceAsync<Stok>();
            return allStock.Where(a => a.Sid == Sid).FirstOrDefault();
        }
        public async Task<Stok> GetStock()
        {
            var allStock = await GetAllStoks();
            await firebase
              .Child("Stock")
              .OnceAsync<Stok>();
            return allStock.FirstOrDefault();
        }


        public async Task UpdateUsuario(string Uid, string email, string password, string Ugrupo, string Uarea)
        {
            var toUpdateUsuario = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.Uid == Uid).FirstOrDefault();

            await firebase
              .Child("Usuarios")
              .Child(toUpdateUsuario.Key)
              .PutAsync(new Usuario() { Uid = Uid, email = email, password = password, Ugrupo = Ugrupo, Uarea = Uarea });
        }
        public async Task UpdateUsuarioStatusLI( string email)
        {
            var toUpdateUsuario = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.email == email).FirstOrDefault();

            var person = await GetUsuarioemail(email);

            await firebase
              .Child("Usuarios")
              .Child(toUpdateUsuario.Key)
              .PutAsync(new Usuario() { Uid=person.Uid,email=person.email,password=person.password, Ugrupo = person.Ugrupo, FechaIngreso=person.FechaIngreso,Uarea=person.Uarea , Status =true });
        }
        public async Task UpdateUsuarioStatusLO(string email)
        {
            var toUpdateUsuario = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.email == email).FirstOrDefault();

            var person = await GetUsuarioemail(email);
            
            await firebase
              .Child("Usuarios")
              .Child(toUpdateUsuario.Key)
              .PutAsync(new Usuario() { Uid = person.Uid, email = person.email, password = person.password, Ugrupo = person.Ugrupo, FechaIngreso = person.FechaIngreso, Uarea = person.Uarea, Status = false });
        }


        public async Task UpdateStock(string Sid)
        {
            var toUpdateStock = (await firebase
              .Child("Stock")
              .OnceAsync<Stok>()).Where(a => a.Object.Sid == Sid).FirstOrDefault();

            var Stock = await GetStockid(Sid);
            var products = await GetAllProductos();

            await firebase
              .Child("Stock")
              .Child(toUpdateStock.Key)
              .PutAsync(new Stok() {  Sid = Stock.Sid, StockAct=products.Count(),StockMax=Stock.StockMax,StockMin=Stock.StockMin});
        }
        public async Task UpdateProducto(string Pid, string Categoria, string Pnombre, double Precio, string Provedor, string Pstockid)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.Pid == Pid).FirstOrDefault();

            
            
            await firebase
              .Child("Productos")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Producto() { Pid = Pid, Categoria = Categoria, Pnombre = Pnombre, Precio = Precio, Provedor = Provedor, Pstockid = Pstockid });
        }
        public async Task UpdateProductostatusD(string Pid)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.Pid == Pid).FirstOrDefault();

            var product = await GetProductoid(Pid);

            await firebase
              .Child("Productos")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Producto() { Pid = product.Pid ,Pnombre= product.Pnombre,Provedor= product.Provedor,Categoria= product.Categoria,Precio= product.Precio,Pstockid= product.Pstockid,evaluado=true,defectuoso=true});
        }
        public async Task UpdateProductostatusA(string Pid)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.Pid == Pid).FirstOrDefault();

            var product = await GetProductoid(Pid);

            await firebase
              .Child("Productos")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Producto() { Pid = product.Pid, Pnombre = product.Pnombre, Provedor = product.Provedor, Categoria = product.Categoria, Precio = product.Precio, Pstockid = product.Pstockid, evaluado = true ,defectuoso=false});
        }

        public async Task DeleteUsuario(string Uid)
        {
            var toDeleteUsuario = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.Uid == Uid).FirstOrDefault();
            await firebase.Child("Usuarios").Child(toDeleteUsuario.Key).DeleteAsync();

        }
        public async Task DeleteProducto(string Pid)
        {
            var toDeleteProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.Pid == Pid).FirstOrDefault();
            await firebase.Child("Productos").Child(toDeleteProducto.Key).DeleteAsync();

        }




    }
}
