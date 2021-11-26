import { boleto } from 'boleto-brasileiro-validator';

window.ValidarCodigoBarras = function (codigoBarras) {
    return boleto(codigoBarras);
}