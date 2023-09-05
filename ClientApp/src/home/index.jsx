import { React, useRef, useEffect } from "react";
import { accountService } from "../_services";
import "./home.css";

import { Page } from "../blocks";

export const Home = () => {
  const ref = useRef(null);
  useEffect(() => {
    setTimeout(() => {
      const element = document.querySelector(".carousel-control-next-icon");
      element.click();
    }, 3000);
  }, []);

  return (
    <Page title="Entropia Universe Auction Helper">
      <div className="row justify-content-center">
        <div className="col-md-10">
          {/*   <!-- Carousel --> */}
          <div
            id="Carousel4"
            className="carousel slide shadow-soft border border-light p-4 rounded"
            data-ride="carousel"
          >
            <ol className="carousel-indicators">
              <li
                data-target="#Carousel4"
                data-slide-to="0"
                className="active"
              ></li>
              <li data-target="#Carousel4" data-slide-to="1"></li>
              <li data-target="#Carousel4" data-slide-to="2"></li>
            </ol>
            <div className="carousel-inner rounded">
              <div className="carousel-item active">
                <img
                  className="d-block w-100"
                  src="../../assets/img/carousel/image-1.jpg"
                  alt="First slide"
                />
                <div class="carousel-caption d-none d-md-block text-dark">
                  <h1 class="h1">Entropia Auction Helper</h1>
                  <p>Start making money playing the game Entropia Universe.</p>
                </div>
              </div>
              <div className="carousel-item">
                <img
                  className="d-block w-100"
                  src="../../assets/img/carousel/image-2.jpg"
                  alt="Second slide"
                />
                <div class="carousel-caption d-none d-md-block text-dark">
                  <h1 class="h1">Entropia Auction Helper</h1>
                  <p>Start making money playing the game Entropia Universe.</p>
                </div>
              </div>
              <div className="carousel-item">
                <img
                  className="d-block w-100"
                  src="../../assets/img/carousel/image-3.jpg"
                  alt="Third slide"
                />
                <div class="carousel-caption d-none d-md-block text-dark">
                  <h1 class="h1">Entropia Auction Helper</h1>
                  <p>Start making money playing the game Entropia Universe.</p>
                </div>
              </div>
            </div>
            <a
              className="carousel-control-prev"
              href="#Carousel4"
              role="button"
              data-slide="prev"
            >
              <span
                className="carousel-control-prev-icon"
                aria-hidden="true"
              ></span>
              <span className="sr-only">Previous</span>
            </a>
            <a
              className="carousel-control-next"
              href="#Carousel4"
              role="button"
              data-slide="next"
            >
              <span
                className="carousel-control-next-icon"
                aria-hidden="true"
              ></span>
              <span className="sr-only">Next</span>
            </a>
          </div>

          {/* <!-- End of Carousel -->*/}
        </div>
      </div>
    </Page>
  );
};
