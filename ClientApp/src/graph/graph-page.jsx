import React from "react";
import { Page } from "../blocks";
import { GraphFormLoading } from "./graph-form-loading";
import GraphDataProvider, { DataContext } from "../context";
import GraphForm from "./graph-form";
import { TableComponent } from "./table";
import { Graph } from "./graph";

export const GraphPage = () => {
  const graphContext = React.useContext(DataContext);

  return (
    <GraphDataProvider>
      <Page>
        {/*<!-- Hero -->*/}

        <div className="section section-header pb-0"></div>

        {/*<!-- End of Hero section -->*/}

        {graphContext?.userItemsLoading ? <GraphFormLoading /> : <GraphForm />}

        {/* <!-- Section of Graph and table -->   */}

        <section className="section pt-0">
          <div className="container-md">
            <div className="row justify-content-center">
              <div className="col-10">
                <div className="card bg-primary shadow-soft border-light p-4">
                  <div className="row justify-content-center">
                    <div className="col-md-8">{<Graph />}</div>
                    <div className="col-md-4">{<TableComponent />}</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
        {/* <!-- End of Section  Graph and table -->   */}
      </Page>
    </GraphDataProvider>
  );
};
