var myChart;

window.plotFunction = (inputX) => {
    // Crear un array para tus datos
    let data = [];

    for (let i = 0; i <= 500; i += 50) {
        data.push({ x: i, y: 161 * i });
    }

    let datosNivel1 = [];
    datosNivel1.push({ x: 130, y: 0 * 130 });
    datosNivel1.push({ x: 130, y: 161 * 130 });

    let datosNivel2 = [];
    datosNivel2.push({ x: 180, y: 0 * 180 });
    datosNivel2.push({ x: 180, y: 161 * 180 });

    let datosNivel3 = [];
    datosNivel3.push({ x: 360, y: 0 * 360 });
    datosNivel3.push({ x: 360, y: 161 * 360 });


    inputX = Math.round(inputX);
    // Calcular el valor y correspondiente para inputX
    let inputY = 161 * inputX;

    // Obtener el elemento canvas del DOM
    let ctx = document.getElementById('myChart').getContext('2d');

    // Destruir el gráfico existente si existe
    if (myChart) {
        myChart.destroy();
    }

    // Crear el gráfico
    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            datasets: [
                {
                    label: 'y = 161*x',
                    data: data,
                    borderColor: 'green', // Cambio de color a verde
                    borderWidth: 1,
                    pointRadius: 0, // Deshabilitar los puntos
                    fill: false, // No rellenar el área bajo la curva
                    showLine: true // Mostrar solo la línea
                }, {
                    label: 'Nivel 1',
                    data: datosNivel1,
                    borderColor: 'red', // Cambio de color a rojo
                    borderWidth: 1,
                    pointRadius: 0, // Deshabilitar los puntos
                    fill: false, // No rellenar el área bajo la curva
                    showLine: true // Mostrar solo la línea
                }, {
                    label: 'Nivel 2',
                    data: datosNivel2,
                    borderColor: 'red', // Cambio de color a rojo
                    borderWidth: 1,
                    pointRadius: 0, // Deshabilitar los puntos
                    fill: false, // No rellenar el área bajo la curva
                    showLine: true // Mostrar solo la línea
                }, {
                    label: 'Nivel 3',
                    data: datosNivel3,
                    borderColor: 'red', // Cambio de color a rojo
                    borderWidth: 1,
                    pointRadius: 0, // Deshabilitar los puntos
                    fill: false, // No rellenar el área bajo la curva
                    showLine: true // Mostrar solo la línea
                },
                {
                    label: `Punto (${inputX}, ${inputY})`,
                    data: [{ x: inputX, y: inputY }],
                    borderColor: 'blue', // Cambio de color a azul
                    backgroundColor: 'blue', // Cambio de color a azul
                    borderWidth: 1,
                    pointRadius: 5,
                    fill: false,
                    showLine: false
                }
            ]
        },
        options: {
            animation: {
                duration: 0 // deshabilita la animación
            },
            scales: {
                x: {
                    type: 'linear',
                    position: 'bottom',
                    beginAtZero: true
                },
                y: {
                    type: 'linear',
                    beginAtZero: true
                }
            }
        }
    });
}
