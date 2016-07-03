var gds = function() {
    var getQueryVariable = function(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0].toLowerCase() == variable.toLowerCase()) {
                return pair[1];
            }
        }
        return null;
    };
    return {
        getQueryVariable: function(variable) {
            return getQueryVariable(variable);
        },
    };
}(gds);