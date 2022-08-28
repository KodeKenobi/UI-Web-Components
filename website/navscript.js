$(document).ready(function () {

  // toggle menu/navbar1 script
  $('.menu-btn').click(function () {
    $('.navbar1 .menu').toggleClass("active");
    $('.menu-btn i').toggleClass("active");
  });

  $('.owl-carousel').owlCarousel({
    loop: true,
    nav: false,
    autoplay: true,
    autoplayTimeout: 5000,
    dots: false,
    stopOnHover: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      1000: {
        items: 1
      }
    }
  });
});