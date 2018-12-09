﻿using Asia.Solid.Domain.Services.Interfaces;

namespace Asia.Solid.Domain.Entities
{
    public class PagamentoCartaoDebito : Pagamento
    {
        private DetalhePagamento _detalhePagamento { get; set; }
        private readonly IGatewayPagamentoService _gatewayPagamentoService;
       
        public PagamentoCartaoDebito(Carrinho carrinho, DetalhePagamento detalhePagamento, IGatewayPagamentoService gatewayPagamentoService)
        {
            _carrinho = carrinho;
            _detalhePagamento = detalhePagamento;
            _gatewayPagamentoService = gatewayPagamentoService;
            FormaPagamento = FormaPagamento.CartaoDebito;
        }

        public override Carrinho EfetuarPagamento()
        {
            _gatewayPagamentoService.EfetuarPagamento("login", "senha", _detalhePagamento, _carrinho.ValorTotalPedido);

            _carrinho.InformarPagamento();

            return _carrinho;
        }
    }
}