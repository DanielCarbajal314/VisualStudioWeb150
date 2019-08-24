var app = new Vue({
    el: '#app',
    data: {
        listaDeProyectos: [],
        proyectoId: null,
        listaDePersonas: [],
        personaId: null,
        Estado: null,
        HoraFin: null,
        HoraInicio: null,
        Observacion: null,
        Nombre: null,
        listaDeActividades: []
    },
    methods: {
        cargarProyectos: function () {
            $.get('/api/GestionDeActividades/Proyectos')
                .then(proyectosEnElServidor => {
                    this.listaDeProyectos.push(...proyectosEnElServidor);
                    if (proyectosEnElServidor.length > 0)
                        this.proyectoId = proyectosEnElServidor[0].Id;
                })
        },
        cargarPersonas: function () {
            $.get('/api/GestionDeActividades/Personal')
                .then(personasEnElServidor => {
                    this.listaDePersonas.push(...personasEnElServidor);
                })
        },
        cargarActividades: function () {
            $.get('/api/GestionDeActividades/Actividades')
                .then(actividadesEnElServidor => {
                    this.listaDeActividades.push(...actividadesEnElServidor);
                })
        },
        GuardarEnElServidor: function () {
            let data = {
                IdPersona: this.personaId,
                IdProyecto: this.proyectoId,
                Nombre: this.Nombre,
                HoraInicio: this.HoraInicio,
                HoraFin: this.HoraFin,
                Observacion: this.Observacion,
                Estado: this.Estado
            };
            post('/api/GestionDeActividades/RegistrarNuevaActividad', data).then(nuevaActividad => {
                this.listaDeActividades.push(nuevaActividad);
                this.LimpiarFormulario();
            });
        },
        LimpiarFormulario: function () {
            this.proyectoId = null;
            this.personaId = null;
            this.Estado = null;
            this.HoraFin = null;
            this.HoraInicio = null;
            this.Observacion = null;
            this.Nombre = null;
        },
        elegirActividad: function (actividad) {
            console.log(actividad);
        }
    }
})

app.cargarProyectos();
app.cargarPersonas();
app.cargarActividades();

function post(url, data) {
    return $.ajax({
        url: url,
        method: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json'
    })
}
