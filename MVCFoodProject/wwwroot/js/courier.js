const apiCLientInstance = new ApiClient({
    apiBase: API_BASE,
    isAuth: true
});

function onToggleOrder(event) {
    const payload = {
        Id: event.target.getAttribute('data-order-id'),
        action: event.target.getAttribute('data-action')
    };

    apiCLientInstance.post(`/orders/toggle`, payload).catch(e => {
        console.error(e)
    });
}

function onCompleteOrder(event) {
    const payload = {
        Id: event.target.getAttribute('data-order-id')
    };

    apiCLientInstance.post(`/orders/complete`, payload).catch(e => {
        console.error(e)
    });

}