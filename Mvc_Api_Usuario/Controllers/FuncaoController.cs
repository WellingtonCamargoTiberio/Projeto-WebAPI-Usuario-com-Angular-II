using Api_Usuario.Entidades;
using Api_Usuario.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Api_Usuario.Controllers
{

    [EnableCors("CorsApi")]

    [Authorize]
    public class FuncaoController : Controller
    {
        private readonly IFuncao IFuncao;

        public FuncaoController(IFuncao IFuncao)
        {
            this.IFuncao = IFuncao;
        }
    [HttpGet("/api/ListaFuncao")]
    public async Task <JsonResult> ListaFuncao()
        {
            return Json(await this.IFuncao.List());
        }
    [HttpPost("/api/AdicionarFuncao")]
    public async Task AdicionarFuncao([FromBody] Funcao funcao)
        {
            await Task.FromResult(this.IFuncao.Add(funcao));
        }
    }
}
