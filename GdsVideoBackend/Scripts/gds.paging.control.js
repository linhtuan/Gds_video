
var callback = null;
var pageSetting = {
    total: 0,
    page: 1,
    pageSize: 50,
};

var callBackController = function() {
    var renderPaging = function(page, total) {
        $('.paging-row').show();
        $('.paging-row .input-mini').val(page);
        $('.paging-row a').text(total);
        $('.paging-row button').removeClass('disabled');
        if (page === 1)
            $('.paging-row button.prev').addClass('disabled');

        if (page === total)
            $('.paging-row button.next').addClass('disabled');
    };

    var calculatePage = function(totalRecord, pageSize) {
        return totalRecord % pageSize == 0 ? (totalRecord / pageSize) : (parseInt(totalRecord / pageSize) + 1);
    };

    var bindingAgainSetting = function (pageIndex, totalRecord, pageSize) {
        pageSetting.page = pageIndex;
        pageSetting.total = calculatePage(totalRecord, pageSize);
        if (pageSetting.total > 1) {
            renderPaging(pageIndex, pageSetting.total);
        }
    };

    return {
        renderPaging: function(page, total) {
            return renderPaging(page, total);
        },

        calculatePage: function(totalRecord, pageSize) {
            return calculatePage(totalRecord, pageSize);
        },
        
        bindingAgainSetting: function (pageIndex, totalRecord, pageSize) {
            return bindingAgainSetting(pageIndex, totalRecord, pageSize);
        },
    };
}(callBackController);

$(document).on('click', '.paging-row button.prev', function () {
	if (!$(this).hasClass('disabled')) {
	    pageSetting.page = pageSetting.page - 1;
	    $('html, body').animate({ scrollTop: 0 }, 0);
	    $('.paging-row .input-mini').val(pageSetting.page);
	    //rtb.setQueryVariable("page", pageSetting.page);
		callback();
	}
});

$(document).on('click', '.paging-row button.next', function () {
	if (!$(this).hasClass('disabled')) {
	    pageSetting.page = pageSetting.page + 1;
	    $('html, body').animate({ scrollTop: 0 }, 0);
	    $('.paging-row .input-mini').val(pageSetting.page);
	    //rtb.setQueryVariable("page", pageSetting.page);
		callback();
	}
});

$(document).on('keydown', '.paging-row .input-mini', function (event) {
	if (event.which == 13) {
		if ($(this).val().trim() == '' || isNaN($(this).val().trim())) return false;
		var thisPage = parseInt($(this).val().trim());
		if (thisPage > pageSetting.total || thisPage <= 0) return false;
		pageSetting.page = parseInt($(this).val().trim());
		$(this).blur();
		$('html, body').scrollTop(0);
		//rtb.setQueryVariable("page", pageSetting.page);
		callback();
	}
});

//$(document).ready(function() {
//    var getPageIndex = rtb.getQueryVariable('page');
//    if (getPageIndex != null && !isNaN(getPageIndex)) {
//        pageSetting.page = parseInt(getPageIndex);
//    }
//});

//function gotoDefaultPage() {
//    pageSetting.page = 1;
//    rtb.setQueryVariable("page", 1);
//}
