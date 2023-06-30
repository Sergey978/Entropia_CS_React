import React from "react";
import { accountService } from "../_services";

import { Page } from "../blocks";

export const About = () => {
  return (
    <Page>
      <main>
        {/*<!-- Hero -->*/}
        <div className="section section-header pb-7">
          <div className="container">
            <div className="row justify-content-center">
              <div className="col-12 col-lg-8 text-center">
                <h1 className="display-2 mb-4">
                  Entropia Universe, how to earn money by playing.
                </h1>
                <p className="lead mb-5">
                  Entropia Universe is based upon a Real Cash Economy. That is
                  because nearly every item in the game has a PED value. Since
                  you can exchange PED for US dollars, every such item in the
                  game also has a real-world cash value.{" "}
                </p>
              </div>
            </div>
          </div>
        </div>
        {/*<!-- End of Hero section -->*/}
        <section className="section section-lg pt-0">
          <div className="container">
            <div className="row">
              <div className="col">
                <div className="card bg-primary shadow-soft border-light p-4">
                  <div className="row">
                    <div className="col-12 col-lg-4 px-md-0 mb-4 mb-lg-0">
                      <div className="card-body text-center bg-primary py-5">
                        <div className="icon icon-shape shadow-inset border-light rounded-circle mb-3">
                          <span className="far fa-eye"></span>
                        </div>
                        {/*<!-- Heading -->*/}
                        <h2 className="h4 mr-2">Idea</h2>
                        {/*<!-- Text -->*/}
                        <p className="mb-0">
                          To understand how you can earn money by playing
                          Entropia Universe, it is a good idea to know a little
                          about the game.
                        </p>
                      </div>
                    </div>
                    <div className="col-12 col-lg-4 px-md-0 mb-4 mb-lg-0">
                      <div className="card-body text-center bg-primary py-5">
                        <div className="icon icon-shape shadow-inset border-light rounded-circle mb-3">
                          <span className="fas fa-medal"></span>
                        </div>
                        {/*<!-- Heading -->*/}
                        <h2 className="h4 mr-2">Investment</h2>
                        {/*<!-- Text -->*/}
                        <p className="mb-0">
                          EU is free to play, but you can boost progress by
                          depositing cash in exchange for PED, or game items.
                          Many people play just for the entertainment, and they
                          are happy to pay to do so.
                        </p>
                      </div>
                    </div>
                    <div className="col-12 col-lg-4 px-md-0">
                      <div className="card-body text-center bg-primary py-5">
                        <div className="icon icon-shape shadow-inset border-light rounded-circle mb-3">
                          <span className="fas fa-puzzle-piece"></span>
                        </div>
                        {/*<!-- Heading -->*/}
                        <h2 className="h4 mr-2">Gameplay</h2>
                        {/*<!-- Text -->*/}
                        <p className="mb-0">
                          Like many Role-Playing Games (RPGs), you can assume
                          one or more roles or occupations. There are many
                          occupations in EU, but the three most common are
                          hunting, mining and crafting. Each activity produces
                          something which you can sell, trade or use to produce
                          a different item.
                        </p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>

        {/*<!-- Section -->*/}
        <section className="section section-lg pt-0">
          <div className="container">
            <div className="row">
              <div className="col-12 col-sm-4 col-lg-4 text-center">
                {/*<!-- Visit Box -->*/}
                <div className="icon-box mb-4">
                  <div className="icon icon-shape shadow-soft border border-light rounded-circle mb-4">
                    <span className="far fa-smile-beam"></span>
                  </div>
                  <h3 className="h5">Team Members</h3>
                  <span className="counter display-3 text-gray d-block">
                    500
                  </span>
                </div>
                {/*<!-- End of Visit Box -->*/}
              </div>
              <div className="col-12 col-sm-4 col-lg-4 text-center">
                {/*<!-- Call Box -->*/}
                <div className="icon-box mb-4">
                  <div className="icon icon-shape shadow-soft border border-light rounded-circle mb-4">
                    <span className="far fa-eye"></span>
                  </div>
                  <h3 className="h5">Projects Published</h3>
                  <span className="counter display-3 text-gray d-block">
                    2400
                  </span>
                </div>
                {/*<!-- End of Call Box -->*/}
              </div>
              <div className="col-12 col-sm-4 col-lg-4 text-center">
                {/*<!-- Email Box -->*/}
                <div className="icon-box mb-4">
                  <div className="icon icon-shape shadow-soft border border-light rounded-circle mb-4">
                    <span className="fas fa-globe-europe"></span>
                  </div>
                  <h3 className="h5">Countries</h3>
                  <span className="counter display-3 text-gray d-block">
                    80
                  </span>
                </div>
                {/*<!-- End of Email Box -->*/}
              </div>
            </div>
          </div>
        </section>
        {/*<!-- End of section -->*/}
      </main>
    </Page>
  );
};
