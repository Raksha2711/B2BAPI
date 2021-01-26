"use strict";
var ScriptsBundle = ScriptsBundle || {};
jQuery(function() {
    ScriptsBundle = {
        init: function() {
			ScriptsBundle.modal();
        },
        modal: function() {
			var dataModal = $('[data-modal]');
			var close = $('[data-close]');
			dataModal.on('click', function() {
				var id = $(this).data('modal');
				$('body').addClass('modal-open');
				$(id).addClass('show');
			});
			
			close.on('click', function() {
				$('body').removeClass('modal-open');
				$('.modal-container').removeClass('show');
			});
		}
       
    };
	
    jQuery(document).ready(ScriptsBundle.init);
	
	//$window.on('scroll', ScriptsBundle.scrollAnimation);
	//$window.on('scroll resize', ScriptsBundle.scrollAnimation);

});