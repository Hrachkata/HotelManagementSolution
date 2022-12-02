﻿
    function resDetails(e) {
        console.log(e.target.parentElement)
            e.preventDefault();
    Swal.fire({
        title: 'Room #: @Model.RoomNumber',
    html: '<div style="font-size: 22px;">Arrival date: @Model.ArrivalDate.ToString("d") <br /> Departure date: @Model.DepartureDate.ToString("d") <br />' +
        '<br />Guest name: @Model.GuestFirstName @Model.GuestLastName  (@Model.GuestNationality)<br />' +
        '<br />Number of guests: @Model.NumberOfGuests / Children: @Model.NumberOfChildren<br />' +
        '<br />Contact info<br />' +
        '<br />Phone number: @Model.GuestPhoneNumber<br />' +
        '<br />Email: @Model.GuestEmail<br />' +
        '<br />Address: @Model.Address<br /></div>' +
    '<br /><b style="font-size: 29px;">Price: @Model.totalPrice</b><br />',
    icon: 'question'

            }
    )
        }

    function resCheckIn(e) {
        e.preventDefault();
    Swal.fire({
        title: 'ID: @Model.Id',
    html: '<br /><b style="font-size: 29px;">Checking in!</b><br />' +
    '<div style="font-size: 22px;">Arrival date: @Model.ArrivalDate.ToString("d") <br /> Departure date: @Model.DepartureDate.ToString("d") <br />' +
        '<br />Guest name: @Model.GuestFirstName @Model.GuestLastName  (@Model.GuestNationality)<br />' +
        '<br />Number of guests: @Model.NumberOfGuests / Children: @Model.NumberOfChildren<br />' +
        '<br /><b style="font-size: 29px;">Price: @Model.totalPrice</b><br />',
        icon: 'success',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Check in!'
            }).then((result) => {
                if (result.isConfirmed) {
            e.target.removeAttribute('onclick');

        e.target.click();
                }
            })
        }

        function resCheckOut(e) {
            e.preventDefault();
        Swal.fire({
            title: 'ID: @Model.Id',
        html: '<br /><b style="font-size: 29px;">Checking out!</b><br />' +
        '<div style="font-size: 22px;">Arrival date: @Model.ArrivalDate.ToString("d") <br /> Departure date: @Model.DepartureDate.ToString("d") <br />' +
            '<br />Guest name: @Model.GuestFirstName @Model.GuestLastName  (@Model.GuestNationality)<br />' +
            '<br />Number of guests: @Model.NumberOfGuests / Children: @Model.NumberOfChildren<br />',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Check out!'
            }).then((result) => {
                if (result.isConfirmed) {
                e.target.removeAttribute('onclick');

            e.target.click();
                }
            })
        }







function resDetails(e, roomNumber, arrivalDate, departureDate, guestFirstName, guestLastName, guestNationality, numberOfGuests, numberOfChildren, guestPhoneNumber, guestEmail, address, totalPrice) {
    console.log(e.target.parentElement.parentElement)
    e.preventDefault();
    Swal.fire({
        title: 'Room #: ${roomNumber}',
        html: '<div style="font-size: 22px;">Arrival date: @Model.ArrivalDate.ToString("d") <br/> Departure date: @Model.DepartureDate.ToString("d") <br/>' +
            '<br />Guest name: @Model.GuestFirstName @Model.GuestLastName  (@Model.GuestNationality)<br />' +
            '<br />Number of guests: @Model.NumberOfGuests / Children: @Model.NumberOfChildren<br />' +
            '<br />Contact info<br />' +
            '<br />Phone number: @Model.GuestPhoneNumber<br />' +
            '<br />Email: @Model.GuestEmail<br />' +
            '<br />Address: @Model.Address<br /></div>' +
            '<br /><b  style="font-size: 29px;">Price: @Model.totalPrice</b><br />',
        icon: 'question'
            
            '@Model.Id', '@Model.RoomNumber', '@Model.ArrivalDate', '@Model.DepartureDate', '@Model.GuestFirstName', '@Model.GuestLastName', '@Model.GuestNationality', '@Model.NumberOfGuests', '@Model.NumberOfChildren', '@Model.GuestPhoneNumber', '@Model.GuestEmail', '@Model.Address', '@Model.totalPrice')">Reservation details</button></td>
}
        )
    }