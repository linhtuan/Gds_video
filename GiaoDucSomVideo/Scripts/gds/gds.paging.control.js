callback = null;

var pageSetting = {
    total: 0,
    page: 1,
    pageSize: 50,
};

var callBackController = function () {
    var renderPaging = function (page, total) {
        var target = $('.paging-ctrl'),
          options = {
              prev: '«',
              next: '»',
              left: 2,
              right: 2,
              click: function (i) {
                  options.page = i;
                  options.pageActive = i;
                  target.pagination(options);
              }
          };
        target.pagination(options);
    };

    return {        
        renderPaging: function (page, total) {
            return renderPaging(page, total);
        },
    };
}(callBackController);