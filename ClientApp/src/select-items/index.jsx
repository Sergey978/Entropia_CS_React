import React from "react";
import { Page } from "../blocks/page";
import {DataService} from "../_services";
import { ItemList } from "../blocks/item-list";

export const SelectItemsPage = () => {
  //for test later change hardcoded
  const userId = 4;

  const { getUserStandartItems, hideStandartItem } = DataService.getInstance();
  const [standartItems, setStandartItems] = React.useState([]);
  const [itemsLoading, setItemsLoading] = React.useState(true);

  React.useEffect(() => {
    let cancelled = false;
    const doGetStandartItems = async () => {
      const customItems = await getUserStandartItems(userId);
      if (!cancelled) {
        setStandartItems(customItems);
        setItemsLoading(false);
      }
    };
    doGetStandartItems();
    return () => {
      cancelled = true;
    };
  }, [userId, itemsLoading]);

  const onHideItem = async (id) => {
    const result = await hideStandartItem(userId, id);
    if (result) {
      setItemsLoading(true);
    }
  };

  return (
    <Page>
      {/*<!-- Hero --> */}
      <div className="section-header pb-6 bg-primary overflow-hidden text-center border-bottom border-light">
        <div className="container z-2">
          <div className="row mb-4 justify-content-center">
            <div className="col-12 col-md-8 col-lg-7">
              <h1 className="display-3 mb-4">Select Standart Items</h1>

              <div className="row justify-content-center">
                <div className="col-lg-10">
                  <div className="mb-6">
                    <ItemList data={standartItems} onHide={onHideItem} />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      {/* <!-- End of Hero -->   */}
    </Page>
  );
};

