class FeedbackServices {
    success(response) {
        if (response.data && response.data.messages && response.data.messages.length) {
            const message = response.data.messages.join(",");
            alert(message);
        } else
            alert('Success.');
    }

    error(e) {
        if (e.data && e.data.messages && e.data.messages.length) {
            const message = e.data.messages.join(",");
            alert(message);
        } else
            alert('Internal error.');
    }
}

export default new FeedbackServices();