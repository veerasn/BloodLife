angular.module('bloodservice').factory('prodService', productlist);

function prodlist() {
    var _code = 'RCSAG'
    var _name = 'Red Cells is SAGM';
    var getProd = function () {
        return _code + ': ' + _name;
    }

    return {
        getProd: getProd
    };
}

