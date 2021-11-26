(()=>{var e={895:e=>{e.exports=function(e){var r={};function t(o){if(r[o])return r[o].exports;var n=r[o]={i:o,l:!1,exports:{}};return e[o].call(n.exports,n,n.exports,t),n.l=!0,n.exports}return t.m=e,t.c=r,t.d=function(e,r,o){t.o(e,r)||Object.defineProperty(e,r,{enumerable:!0,get:o})},t.r=function(e){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},t.t=function(e,r){if(1&r&&(e=t(e)),8&r)return e;if(4&r&&"object"==typeof e&&e&&e.__esModule)return e;var o=Object.create(null);if(t.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:e}),2&r&&"string"!=typeof e)for(var n in e)t.d(o,n,function(r){return e[r]}.bind(null,n));return o},t.n=function(e){var r=e&&e.__esModule?function(){return e.default}:function(){return e};return t.d(r,"a",r),r},t.o=function(e,r){return Object.prototype.hasOwnProperty.call(e,r)},t.p="",t(t.s=7)}([function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.clearMask=function(e){return e.replace(/( |\.|-)/g,"")}},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.boletoBancarioCodigoBarras=u,r.boletoBancarioLinhaDigitavel=i,r.boletoBancario=function(e){var r=arguments.length>1&&void 0!==arguments[1]&&arguments[1],t=(0,a.clearMask)(e);return 44===t.length?u(t):47===t.length&&i(e,r)};var o=t(3),n=t(2),a=t(0);function u(e){var r=(0,a.clearMask)(e);if(!/^[0-9]{44}$/.test(r))return!1;var t=r[4],n=r.substring(0,4)+r.substring(5);return(0,o.modulo11Bancario)(n)===Number(t)}function i(e){var r=arguments.length>1&&void 0!==arguments[1]&&arguments[1],t=(0,a.clearMask)(e);if(!/^[0-9]{47}$/.test(t))return!1;var i=[{num:t.substring(0,9),DV:t.substring(9,10)},{num:t.substring(10,20),DV:t.substring(20,21)},{num:t.substring(21,31),DV:t.substring(31,32)}],c=!r||i.every((function(e){return(0,o.modulo10)(e.num)===Number(e.DV)})),l=u((0,n.convertToBoletoBancarioCodigoBarras)(t));return c&&l}},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.convertToBoletoArrecadacaoCodigoBarras=function(e){for(var r=(0,o.clearMask)(e),t="",n=0;n<4;n++){var a=11*n+n,u=11*(n+1)+n;t+=r.substring(a,u)}return t},r.convertToBoletoBancarioCodigoBarras=function(e){var r=(0,o.clearMask)(e),t="";return t+=r.substring(0,3),t+=r.substring(3,4),t+=r.substring(32,33),t+=r.substring(33,37),t+=r.substring(37,47),t+=r.substring(4,9),(t+=r.substring(10,20))+r.substring(21,31)};var o=t(0)},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.modulo10=function(e){var r=e.split("").reverse().reduce((function(e,r,t){var o=Number(r)*((t+1)%2+1);return e+(o>9?Math.trunc(o/10)+o%10:o)}),0);return 10*Math.ceil(r/10)-r},r.modulo11Bancario=function(e){var r=2,t=11-e.split("").reverse().reduce((function(e,t){var o=Number(t)*r;return r=9===r?2:r+1,e+o}),0)%11;return 0===t||10===t||11===t?1:t},r.modulo11Arrecadacao=function(e){var r=2,t=e.split("").reverse().reduce((function(e,t){var o=Number(t)*r;return r=9===r?2:r+1,e+o}),0)%11;return 0===t||1===t?0:10===t?1:11-t}},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.boletoArrecadacaoCodigoBarras=u,r.boletoArrecadacaoLinhaDigitavel=i,r.boletoArrecadacao=function(e){var r=arguments.length>1&&void 0!==arguments[1]&&arguments[1],t=(0,a.clearMask)(e);return 44===t.length?u(t):48===t.length&&i(e,r)};var o=t(3),n=t(2),a=t(0);function u(e){var r=(0,a.clearMask)(e);if(!/^[0-9]{44}$/.test(r)||8!==Number(r[0]))return!1;var t=Number(r[2]),n=Number(r[3]),u=r.substring(0,3)+r.substring(4),i=void 0;if(6===t||7===t)i=o.modulo10;else{if(8!==t&&9!==t)return!1;i=o.modulo11Arrecadacao}return i(u)===n}function i(e){var r=arguments.length>1&&void 0!==arguments[1]&&arguments[1],t=(0,a.clearMask)(e);if(!/^[0-9]{48}$/.test(t)||8!==Number(t[0]))return!1;var i=u((0,n.convertToBoletoArrecadacaoCodigoBarras)(t));if(!r)return i;var c=Number(t[2]),l=void 0;if(6===c||7===c)l=o.modulo10;else{if(8!==c&&9!==c)return!1;l=o.modulo11Arrecadacao}return Array.from({length:4},(function(e,r){var o=11*r+r,n=11*(r+1)+r;return{num:t.substring(o,n),DV:t.substring(n,n+1)}})).every((function(e){return l(e.num)===Number(e.DV)}))&&i}},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0}),r.boleto=function(e){var r=arguments.length>1&&void 0!==arguments[1]&&arguments[1],t=(0,a.clearMask)(e);return 8===Number(t[0])?(0,o.boletoArrecadacao)(t,r):(0,n.boletoBancario)(t,r)};var o=t(4),n=t(1),a=t(0)},function(e,r,t){"use strict";Object.defineProperty(r,"__esModule",{value:!0});var o=t(4);Object.defineProperty(r,"boletoArrecadacao",{enumerable:!0,get:function(){return o.boletoArrecadacao}}),Object.defineProperty(r,"boletoArrecadacaoCodigoBarras",{enumerable:!0,get:function(){return o.boletoArrecadacaoCodigoBarras}}),Object.defineProperty(r,"boletoArrecadacaoLinhaDigitavel",{enumerable:!0,get:function(){return o.boletoArrecadacaoLinhaDigitavel}});var n=t(1);Object.defineProperty(r,"boletoBancario",{enumerable:!0,get:function(){return n.boletoBancario}}),Object.defineProperty(r,"boletoBancarioCodigoBarras",{enumerable:!0,get:function(){return n.boletoBancarioCodigoBarras}}),Object.defineProperty(r,"boletoBancarioLinhaDigitavel",{enumerable:!0,get:function(){return n.boletoBancarioLinhaDigitavel}});var a=t(5);Object.defineProperty(r,"boleto",{enumerable:!0,get:function(){return a.boleto}})},function(e,r,t){e.exports=t(6)}])}},r={};function t(o){var n=r[o];if(void 0!==n)return n.exports;var a=r[o]={exports:{}};return e[o](a,a.exports,t),a.exports}t.n=e=>{var r=e&&e.__esModule?()=>e.default:()=>e;return t.d(r,{a:r}),r},t.d=(e,r)=>{for(var o in r)t.o(r,o)&&!t.o(e,o)&&Object.defineProperty(e,o,{enumerable:!0,get:r[o]})},t.o=(e,r)=>Object.prototype.hasOwnProperty.call(e,r),(()=>{"use strict";var e=t(895);window.ValidarCodigoBarras=function(r){return(0,e.boleto)(r)}})()})();