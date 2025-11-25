using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBook.Domain.Entities
{
    public class Usuario
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = string.Empty; 

        [Required]
        [MaxLength(20)]
        [Column("identificacion")]
        public string Identificacion { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("contrasena_hash")]
        public string ContrasenaHash { get; set; } = string.Empty;

        [Required]
        [Column("rol")]
        public RolUsuario Rol { get; set; }

        [Required]
        [Column("cuenta_confirmada")]
        public bool CuentaConfirmada { get; set; }

        [Required]
        [Column("activo")]
        public ActivoUsuario Activo { get; set; }

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        // Relación con Ventas
        public ICollection<Venta>? VentasRealizadas { get; set; }
    }
}