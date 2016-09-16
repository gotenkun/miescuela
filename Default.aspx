<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentStyles" runat="Server">
    <!-- Fonts START -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700|PT+Sans+Narrow|Source+Sans+Pro:200,300,400,600,700,900&amp;subset=all" rel="stylesheet" type="text/css">
    <!-- Fonts END -->

    <!-- Global styles START -->
    <link href="/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Global styles END -->

    <!-- Page level plugin styles START -->
    <link href="/assets/global/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet">
    <link href="/assets/global/plugins/carousel-owl-carousel/owl-carousel/owl.carousel.css" rel="stylesheet">
    <link href="/assets/global/plugins/slider-revolution-slider/rs-plugin/css/settings.css" rel="stylesheet">
    <!-- Page level plugin styles END -->

    <!-- Theme styles START -->
    <link href="/assets/global/css/components.css" rel="stylesheet">
    <link href="/assets/frontend/layout/css/style.css" rel="stylesheet">
    <link href="/assets/frontend/pages/css/style-revolution-slider.css" rel="stylesheet">
    <!-- metronic revo slider styles -->
    <link href="/assets/frontend/layout/css/style-responsive.css" rel="stylesheet">
    <link href="/assets/frontend/layout/css/themes/red.css" rel="stylesheet" id="style-color">
    <link href="/assets/frontend/layout/css/custom.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="Server">
    <!-- BEGIN SLIDER -->
    <div class="page-slider margin-bottom-40">
        <div class="fullwidthbanner-container-fluid revolution-slider">
            <div class="fullwidthabnner">
                <ul id="revolutionul">
                    <!-- THE NEW SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="/assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="/img/bg1.jpg" alt="">

                        <div class="caption lft slide_title_white slide_item_left"
                            data-x="30"
                            data-y="90"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            Conoce las escuelas <br>
                            <span class="slide_title_white_bold">de Jalisco</span>
                        </div>
                        <div class="caption lft slide_subtitle_white slide_item_left"
                            data-x="87"
                            data-y="245"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                           Busca en nuestro directorio de escuelas
             
                        </div>
                        <a class="caption lft btn dark slide_btn slide_item_left" href="/Escuelas"
                            data-x="187"
                            data-y="315"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Buscar Escuelas
              </a>
                        <div class="caption lfb"
                            data-x="640"
                            data-y="0"
                            data-speed="700"
                            data-start="1000"
                            data-easing="easeOutExpo">
                            <img src="/img/Lupita.png" alt="Image 1" width="400">
                        </div>
                    </li>

                    <!-- THE FIRST SLIDE -->
                    <li data-transition="fade" data-slotamount="8" data-masterspeed="700" data-delay="9400" data-thumb="/assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <!-- THE MAIN IMAGE IN THE FIRST SLIDE -->
                        <img src="/assets/frontend/pages/img/revolutionslider/bg1.jpg" alt="">

                        <div class="caption lft slide_title slide_item_left"
                            data-x="30"
                            data-y="105"
                            data-speed="400"
                            data-start="1500"
                            data-easing="easeOutExpo">
                            Comunicación eficiente
             
                        </div>
                        <div class="caption lft slide_subtitle slide_item_left"
                            data-x="30"
                            data-y="180"
                            data-speed="400"
                            data-start="2000"
                            data-easing="easeOutExpo">
                            Tecnología para mejorar escuelas
             
                        </div>
                        <div class="caption lft slide_desc slide_item_left"
                            data-x="30"
                            data-y="220"
                            data-speed="400"
                            data-start="2500"
                            data-easing="easeOutExpo">
                            Forma parte de la escuela de tus hijos<br>
                            dando a conocer tu opinión e incluso proponer ideas.
             
                        </div>
                        <a class="caption lft btn green slide_btn slide_item_left" href="/Admin/Inicio"
                            data-x="30"
                            data-y="290"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutExpo">Iniciar Sesión
              </a>
                        <div class="caption lfb"
                            data-x="640"
                            data-y="55"
                            data-speed="700"
                            data-start="1000"
                            data-easing="easeOutExpo">
                            <img src="/assets/frontend/pages/img/revolutionslider/man-winner.png" alt="Image 1">
                        </div>
                    </li>

                    <!-- THE SECOND SLIDE -->
                    <li data-transition="fade" data-slotamount="7" data-masterspeed="300" data-delay="9400" data-thumb="/assets/frontend/pages/img/revolutionslider/thumbs/thumb2.jpg">
                        <img src="/assets/frontend/pages/img/revolutionslider/bg2.jpg" alt="">
                        <div class="caption lfl slide_title slide_item_left"
                            data-x="30"
                            data-y="125"
                            data-speed="400"
                            data-start="3500"
                            data-easing="easeOutExpo">
                            Acceso Universal
             
                        </div>
                        <div class="caption lfl slide_subtitle slide_item_left"
                            data-x="30"
                            data-y="200"
                            data-speed="400"
                            data-start="4000"
                            data-easing="easeOutExpo">
                            Ingresa desde cualquier dispositivo 
             
                        </div>
                        <div class="caption lfl slide_desc slide_item_left"
                            data-x="30"
                            data-y="245"
                            data-speed="400"
                            data-start="4500"
                            data-easing="easeOutExpo">
                            Usa el sitio de internet o nuestras Apps <br />
                            para ser parte esencial del crecimiento escolar
             
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="635"
                            data-y="105"
                            data-speed="1200"
                            data-start="1500"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/mac.png" alt="Image 1">
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="580"
                            data-y="245"
                            data-speed="1200"
                            data-start="2000"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/ipad.png" alt="Image 1">
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="735"
                            data-y="290"
                            data-speed="1200"
                            data-start="2500"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/iphone.png" alt="Image 1">
                        </div>
                        <div class="caption lfr slide_item_right"
                            data-x="835"
                            data-y="230"
                            data-speed="1200"
                            data-start="3000"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/macbook.png" alt="Image 1">
                        </div>
                      <%--  <div class="caption lft slide_item_right"
                            data-x="865"
                            data-y="45"
                            data-speed="500"
                            data-start="5000"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/hint1-red.png" id="rev-hint1" alt="Image 1">
                        </div>--%>
                      <%--  <div class="caption lfb slide_item_right"
                            data-x="355"
                            data-y="355"
                            data-speed="500"
                            data-start="5500"
                            data-easing="easeOutBack">
                            <img src="/assets/frontend/pages/img/revolutionslider/hint2-red.png" id="rev-hint2" alt="Image 1">
                        </div>--%>
                    </li>

                    <!-- THE THIRD SLIDE -->
                   
                </ul>
                <div class="tp-bannertimer tp-bottom"></div>
            </div>
        </div>
    </div>
    <!-- END SLIDER -->
    <div class="main">
        <div class="container">
            <!-- BEGIN SERVICE BOX -->
            <div class="row service-box margin-bottom-40">
                <div class="col-md-4 col-sm-4">
                    <div class="service-box-heading">
                        <em><i class="fa fa-location-arrow blue"></i></em>
                        <span>Sé Parte de Tu Escuela</span>
                    </div>
                    <p>No importa si eres alumno o padre de familia, Puedes ser parte de tu escuela, participando de manera activa.</p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="service-box-heading">
                        <em><i class="fa fa-check red"></i></em>
                        <span>Califica tu escuela</span>
                    </div>
                    <p>Utiliza herramientas de tecnología para calificar cada área de tu escuela, así todos conoceremos la realidad de tu escuela.</p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="service-box-heading">
                        <em><i class="fa fa-compress green"></i></em>
                        <span>Comunicación Activa</span>
                    </div>
                    <p>Mantenga contacto directo con los actores principales de tu escuela, maestros, directores, trabajadores social.</p>
                </div>
            </div>
            <!-- END SERVICE BOX -->

            <!-- BEGIN BLOCKQUOTE BLOCK -->
            <div class="row quote-v1 margin-bottom-30">
                <div class="col-md-9">
                    <span>#MIESCUELA - Conoce y sé parte de tu escuela AHORA</span>
                </div>
                <div class="col-md-3 text-right">
                    <a class="btn-transparent" href="/Admin/Inicio" target="_blank"><i class="fa fa-rocket margin-right-10"></i>Iniciar Sesión</a>
                </div>
            </div>
            <!-- END BLOCKQUOTE BLOCK -->

            <!-- BEGIN RECENT WORKS -->
            <div class="row recent-work margin-bottom-40">
                <div class="col-md-3">
                    <h2><a href="portfolio.html">¿Qué Puedo Hacer?</a></h2>
                    <p>Siendo parte de esta plataforma puedes conocer mucha información oficial y del día a día de escuelas de Jalisco.</p>
                </div>
                <div class="col-md-9">
                    <div class="owl-carousel owl-carousel3">
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img1.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img1.jpg" class="fancybox-button" title="Project Name #1" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img2.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img2.jpg" class="fancybox-button" title="Project Name #2" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img3.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img3.jpg" class="fancybox-button" title="Project Name #3" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img4.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img4.jpg" class="fancybox-button" title="Project Name #4" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img5.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img5.jpg" class="fancybox-button" title="Project Name #5" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img6.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img6.jpg" class="fancybox-button" title="Project Name #6" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img3.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img3.jpg" class="fancybox-button" title="Project Name #3" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                        <div class="recent-work-item">
                            <em>
                                <img src="/assets/frontend/pages/img/works/img4.jpg" alt="Amazing Project" class="img-responsive">
                                <a href="portfolio-item.html"><i class="fa fa-link"></i></a>
                                <a href="/assets/frontend/pages/img/works/img4.jpg" class="fancybox-button" title="Project Name #4" data-rel="fancybox-button"><i class="fa fa-search"></i></a>
                            </em>
                            <a class="recent-work-description" href="#">
                                <strong>Amazing Project</strong>
                                <b>Agenda corp.</b>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END RECENT WORKS -->

            <!-- BEGIN TABS AND TESTIMONIALS -->
            <div class="row mix-block margin-bottom-40">
                <!-- TABS -->
                <div class="col-md-12 tab-style-1">
                    <h2>¿Cómo interactuamos en #MIESCUELA?</h2>
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#tab-1" data-toggle="tab">Padres de Familia</a></li>
                        <li><a href="#tab-2" data-toggle="tab">Alumnos</a></li>
                        <li><a href="#tab-3" data-toggle="tab">Docentes</a></li>
                        <li><a href="#tab-4" data-toggle="tab">Directores</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane row fade in active" id="tab-1">
                          <%--  <div class="col-md-3 col-sm-3">
                                <a href="assets/temp/photos/img7.jpg" class="fancybox-button" title="Image Title" data-rel="fancybox-button">
                                    <img class="img-responsive" src="/assets/frontend/pages/img/photos/img7.jpg" alt="">
                                </a>
                            </div>--%>
                            <div class="col-md-9 col-sm-9">
                                <p class="margin-bottom-10">Como padre de familia, esta plataforma le permite tomar parte de la escuela de sus hijos, revisando qué tareas tienen, votando ideas, calificando áreas, y manteniendo comunicación directa con los profesores.</p>
                                <%--<p><a class="more" href="#">Read more <i class="icon-angle-right"></i></a></p>--%>
                            </div>
                        </div>
                        <div class="tab-pane row fade" id="tab-2">
                            <div class="col-md-9 col-sm-9">
                               <p>Los alumnos pueden votar y sugerir mejoras a su escuela. Pueden también leer su tarea y comunicarse con su maestro. Tienen acceso a un área de ayuda social, de manera privada, </p>
                            </div>
                           <%-- <div class="col-md-3 col-sm-3">
                                <a href="assets/temp/photos/img10.jpg" class="fancybox-button" title="Image Title" data-rel="fancybox-button">
                                    <img class="img-responsive" src="/assets/frontend/pages/img/photos/img10.jpg" alt="">
                                </a>
                            </div>--%>
                        </div>
                        <div class="tab-pane fade" id="tab-3">
                           <p>Como docente, puede haber acceso directo a la comunicación con padres de familia, dejar tareas de forma electrónica y por supuesto ser parte en votaciones de calidad de ideas y áreas escolares</p>
                        </div>
                        <div class="tab-pane fade" id="tab-4">
                           <p>Los directores pueden mantener y agregar información escolar, e indicar comentarios, noticias y eventos para la comunidad escolar.</p>
                        </div>
                    </div>
                </div>
                <!-- END TABS -->

                <!-- TESTIMONIALS -->
               <%-- <div class="col-md-5 testimonials-v1">
                    <div id="myCarousel" class="carousel slide">
                        <!-- Carousel items -->
                        <div class="carousel-inner">
                            <div class="active item">
                                <blockquote>
                                    <p>Denim you probably haven't heard of. Lorem ipsum dolor met consectetur adipisicing sit amet, consectetur adipisicing elit, of them jean shorts sed magna aliqua. Lorem ipsum dolor met.</p>
                                </blockquote>
                                <div class="carousel-info">
                                    <img class="pull-left" src="/assets/frontend/pages/img/people/img1-small.jpg" alt="">
                                    <div class="pull-left">
                                        <span class="testimonials-name">Lina Mars</span>
                                        <span class="testimonials-post">Commercial Director</span>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <blockquote>
                                    <p>Raw denim you Mustache cliche tempor, williamsburg carles vegan helvetica probably haven't heard of them jean shorts austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica.</p>
                                </blockquote>
                                <div class="carousel-info">
                                    <img class="pull-left" src="/assets/frontend/pages/img/people/img5-small.jpg" alt="">
                                    <div class="pull-left">
                                        <span class="testimonials-name">Kate Ford</span>
                                        <span class="testimonials-post">Commercial Director</span>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <blockquote>
                                    <p>Reprehenderit butcher stache cliche tempor, williamsburg carles vegan helvetica.retro keffiyeh dreamcatcher synth. Cosby sweater eu banh mi, qui irure terry richardson ex squid Aliquip placeat salvia cillum iphone.</p>
                                </blockquote>
                                <div class="carousel-info">
                                    <img class="pull-left" src="/assets/frontend/pages/img/people/img2-small.jpg" alt="">
                                    <div class="pull-left">
                                        <span class="testimonials-name">Jake Witson</span>
                                        <span class="testimonials-post">Commercial Director</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Carousel nav -->
                        <a class="left-btn" href="#myCarousel" data-slide="prev"></a>
                        <a class="right-btn" href="#myCarousel" data-slide="next"></a>
                    </div>
                </div>--%>
                <!-- END TESTIMONIALS -->
            </div>
            <!-- END TABS AND TESTIMONIALS -->

            <!-- BEGIN STEPS -->
            <div class="row margin-bottom-40 front-steps-wrapper front-steps-count-3">
                <div class="col-md-4 col-sm-4 front-step-col">
                    <div class="front-step front-step1">
                        <h2>Solicita tu clave</h2>
                        <p>Una vez que tus hijos estén inscritos, puedes solicitar tu clave y contraseña.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 front-step-col">
                    <div class="front-step front-step2">
                        <h2>Ingresa</h2>
                        <p>Inicia sesión en nuestro sitio o app con la clave y contraseña que te proporcionamos.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 front-step-col">
                    <div class="front-step front-step3">
                        <h2>Interactua</h2>
                        <p>Califica, comunica y expresa tus ideas. Podrás compartirlas en redes sociales.</p>
                    </div>
                </div>
            </div>
            <!-- END STEPS -->

            <!-- BEGIN CLIENTS -->
<%--            <div class="row margin-bottom-40 our-clients">
                <div class="col-md-3">
                    <h2><a href="#">Our Clients</a></h2>
                    <p>Lorem dipsum folor margade sitede lametep eiusmod psumquis dolore.</p>
                </div>
                <div class="col-md-9">
                    <div class="owl-carousel owl-carousel6-brands">
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_1_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_1.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_2_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_2.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_3_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_3.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_4_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_4.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_5_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_5.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_6_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_6.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_7_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_7.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                        <div class="client-item">
                            <a href="#">
                                <img src="/assets/frontend/pages/img/clients/client_8_gray.png" class="img-responsive" alt="">
                                <img src="/assets/frontend/pages/img/clients/client_8.png" class="color-img img-responsive" alt="">
                            </a>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- END CLIENTS -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentScript" runat="Server">
    <!-- BEGIN PAGE LEVEL JAVASCRIPTS (REQUIRED ONLY FOR CURRENT PAGE) -->
    <script src="/assets/global/plugins/fancybox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <!-- pop up -->
    <script src="/assets/global/plugins/carousel-owl-carousel/owl-carousel/owl.carousel.min.js" type="text/javascript"></script>
    <!-- slider for products -->

    <!-- BEGIN RevolutionSlider -->

    <script src="/assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.revolution.min.js" type="text/javascript"></script>
    <script src="/assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.tools.min.js" type="text/javascript"></script>
    <script src="/assets/frontend/pages/scripts/revo-slider-init.js" type="text/javascript"></script>
    <!-- END RevolutionSlider -->
    <script src="/assets/frontend/layout/scripts/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Layout.init();
            Layout.initOWL();
            RevosliderInit.initRevoSlider();
            Layout.initTwitter();
            //Layout.initFixHeaderWithPreHeader(); /* Switch On Header Fixing (only if you have pre-header) */
            //Layout.initNavScrolling(); 
        });
    </script>
</asp:Content>

