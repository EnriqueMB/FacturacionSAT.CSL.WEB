/** 
 * Mostramos un mensaje al usuario dependiendo del tipo.  
 * @param {string} message Mensaje a mostrar
 * @param {string} typeMessage Si es 1 = Success || 2 = Error
 * @return {void}
 */
function Mensaje(message, typeMessage) {
    
    if (typeMessage && message) {
        if (typeMessage == '1') {
            
            $('#Success').html('<h3>' + message + '<h3>');
            $('#Success').css("display", "block");
            $('#Success').delay(400).slideDown(400).delay(2000).slideUp(400);
            $('#Success').css("display", "block");

            $('html,body').animate({
                scrollTop: $("#Success").offset().top
            }, 1000);
        }
        else if (typeMessage == '2') {
            $('#Error').html('<h3>' + message + '<h3>');
            $('#Error').css("display", "block");
            $('#Error').delay(400).slideDown(400).delay(2000).slideUp(400);
            $('#Error').css("display", "block");

            $('html,body').animate({
                scrollTop: $("#Error").offset().top
            }, 1000);
        }

    }
}
    