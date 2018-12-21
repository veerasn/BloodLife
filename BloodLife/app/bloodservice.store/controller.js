bloodserviceApp.controller('storeController', ['$scope', function ($scope)
{
    //Blood products
    $scope.bloodproducts = [
        {
            prodgroup: 1,
            prodid: 'RCWB',
            prodname: 'Whole blood',
            prodcharge: 234,
            noreq: 0
        },
        {
            prodgroup: 1,
            prodid: 'RCSAG',
            prodname: 'Red cells in additive solution (SAGM)',
            prodcharge: 234,
            noreq: 0
        },
        {
            prodgroup: 1,
            prodid: 'RCSAG-LD',
            prodname: 'Leucodepleted red cells in additive solution (SAGM)',
            prodcharge: 234,
            noreq: 0
        },
        {
            prodgroup: 1,
            prodid: 'RCWB-ET',
            prodname: 'Red cells for exchange transfusion',
            prodcharge: 234,
            noreq: 0
        },
        {
            prodgroup: 2,
            prodid: 'PLTRD',
            prodname: 'Random donor platelets',
            prodcharge: 234,
            noreq: 0
        },
        {
            prodgroup: 2,
            prodid: 'PLAP',
            prodname: 'Leucodepleted single donor apheresis platelets',
            prodcharge: 234,
            noreq: 0
        }
    ];

    //Product indications
    $scope.indications = [
        {
            prodgroup: 1,
            code: 1,
            caption: "Symptomatic anaemia, Hb 91 - 100 g/L",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 2,
            caption: "Symptomatic anaemia, Hb 81 - 90 g/L",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 3,
            caption: "Symptomatic anaemia, Hb 71 - 80 g/L",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 4,
            caption: "Symptomatic anaemia, Hb < 71 g/L g/L",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 5,
            caption: "Prophylactic. Pre-procedure or pre-therapy Hb optimisation",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 6,
            caption: "Ongoing acute haemorrhage",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 7,
            caption: "Chronic bleeding",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 8,
            caption: "Pre-operative request",
            isChecked: false
        },
        {
            prodgroup: 1,
            code: 9,
            caption: "Massive haemorrhage",
            isChecked: false
        },
        {
            prodgroup: 2,
            code: 10,
            caption: "Prophylactic. No or grade 1 bleeding only. Platelet count < 10",
            isChecked: false
        },
        {
            prodgroup: 2,
            code: 11,
            caption: "Prophylactic. No or grade 1 bleeding only. Platelet count 10 - 20",
            isChecked: false
        }
    ];

    $scope.timings = [
        {
            timerequired: "For transfusion within 30 minutes of sample receipt",
            isChecked: false
        },
        {
            timerequired: "For transfusion within 1 - 2 hours of sample receipt",
            isChecked: false
        },
        {
            timerequired: "Pre-procedural. Group, screen and hold only",
            isChecked: false
        }
    ];

    $scope.procedurenames = ["TKR", "TAHBSO", "Laporatomy"];
    $scope.procedureneeds = ["Pickup", "In reserve", "GSH"];

    $scope.plusOne = function (noreq) {
        $scope.bloodproducts[noreq].noreq += 1;
    };

    $scope.productFilter = { prodgroup: 0 };
    $scope.filterByProduct = function (prodgroup) {
        if ($scope.productFilter.prodgroup === prodgroup) {
            $scope.productFilter = {prodgroup};
        }
        else {
            $scope.productFilter.prodgroup = prodgroup;
        }
    };

}]);
