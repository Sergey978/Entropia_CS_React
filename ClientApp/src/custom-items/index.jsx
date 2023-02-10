import React from "react";
import { Page, ItemList, AddItemForm } from "../blocks";
import {apiService} from "../_services";

export const CustomItemsPage = () => {


    //for test later change hardcoded 
   

    
    const [customItems, setCustomItems] = React.useState([]);
    const [itemsLoading, setItemsLoading] = React.useState(true);
    const [successfullySubmitted, setSuccessfullySubmitted] = React.useState(
        false
    );
    const [successfullyDeleted, setSuccessfullyDeleted] = React.useState(
        false
    );



    React.useEffect(() => {
        let cancelled = false;
        const doGetCustomItems = async () => {
            const customItems = await apiService.getCustomtItems();
            if (!cancelled) {
                console.log(customItems);
                setCustomItems(customItems);
                setItemsLoading(false);
            }
        };
        doGetCustomItems();
        return () => {
            cancelled = true;
        };
    }, [successfullySubmitted, successfullyDeleted, itemsLoading]);

    // todo send _submitResult function to form
    const submitResult = (result) => {
        setSuccessfullySubmitted(result ? true : false);
    }

    const alertCloseclick = (action) => {
        if (action === "add") setSuccessfullySubmitted(false);
        if (action === "delete") setSuccessfullyDeleted(false);
    }

    const onDeleteCustomItem = async (id) => {
        const result = await deleteCustomItem( id);
        if (result) {
            setSuccessfullyDeleted(result ? true : false);
        }

    }

    const onHideItem = async (id) => {
        const result = await hideCustomItem( id);
        if (result) {
            setItemsLoading(true);

        }
    }



    return (
        <Page>

            {/*<!-- Hero --> */}
            <div className="section-header pb-6 bg-primary overflow-hidden text-center border-bottom border-light">
                <div className="container z-2">
                    <div className="row mb-4 justify-content-center">
                        <div className="col-12 col-md-8 col-lg-7">

                            <h1 className="display-3 mb-4">Custom Items</h1>

                            <div className="row justify-content-center">

                                <div className="col-lg-10">
                                    <div className="mb-6">
                                        <ItemList data={customItems}
                                            onDelete={onDeleteCustomItem}
                                            _deleted={successfullyDeleted}
                                            onHide={onHideItem} />

                                        {successfullySubmitted && (
                                            <div className="alert alert-success alert-dismissible shadow-soft fade show" role="alert">
                                                <span className="alert-inner--icon"><span className="far fa-thumbs-up"></span></span>
                                                <span className="alert-inner--text"><strong>Well done!</strong> Your item was successfully added.</span>
                                                <button type="button" className="close" data-dismiss="alert" onClick={() => alertCloseclick("add")}>
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>

                                        )}

                                        {successfullyDeleted && (
                                            <div className="alert alert-danger alert-dismissible shadow-soft fade show" role="alert">
                                                <span className="alert-inner--icon"><span className="far fa-thumbs-up"></span></span>
                                                <span className="alert-inner--text"><strong>Well done!</strong> Your item was successfully deleted.</span>
                                                <button type="button" className="close" data-dismiss="alert" onClick={() => alertCloseclick("delete")}>
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>

                                        )}


                                        <AddItemForm _submitResult={submitResult} _submited={successfullySubmitted} />
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

