import React from 'react';
import { accountService } from '../_services';


import { Page } from "../blocks";


export const Home = () => {
  return (
    <Page title="Home page">     
      <div className="row justify-content-center">
        <div className="col-md-10">
          {/*<!-- Carousel -->*/}
          <div
            id="Carousel1"
            className="carousel slide shadow-soft border border-light p-4 rounded"
            data-ride="carousel"
          >
            <div className="carousel-inner rounded">
              <div className="carousel-item active">
                <img
                  src="../../assets/img/carousel/image-1.jpg"
                  className="d-block w-100"
                  alt="slide1"
                />
              </div>
              <div className="carousel-item">
                <img
                  src="../../assets/img/carousel/image-2.jpg"
                  className="d-block w-100"
                  alt="slide2"
                />
              </div>
              <div className="carousel-item">
                <img
                  src="../../assets/img/carousel/image-3.jpg"
                  className="d-block w-100"
                  alt="slide3"
                />
              </div>
            </div>
          </div>
          {/* <!-- End of Carousel -->*/}
        </div>
      </div>
    </Page>
  );
};

