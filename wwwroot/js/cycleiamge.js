var images = ['https://dmn-dallas-news-prod.cdn.arcpublishing.com/resizer/7wxDuysOsH5nO9RXPhnPnsIzMC0=/1660x1107/smart/filters:no_upscale()/cloudfront-us-east-1.images.arcpublishing.com/dmn/CEPCXDM5SRFUNAGMSP2LG24WH4.jpg', 'https://tastet.ca/wp-content/uploads/2021/08/sdc-cotes-des-neiges-carolineperronphotographies.jpg', 'https://regenbrampton.com/wp-content/uploads/2021/04/shutterstock_752375134-1024x672.png', 'https://tastet.ca/wp-content/uploads/2022/03/page10-11-08-creditcarolineperron.jpg'];
    index  = 0;
    var i = 0;
    function loop() {
    if(i > (images.length - 1)){
        i = 0;
    }

    Document.body.style.backgroundImage = url(images[i]);
    i++;
    loopTimer = setTimeout(loop ,1000);
    }
    loop();
    