﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace GCC
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class CONTACTOSEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new CONTACTOSEntities object using the connection string found in the 'CONTACTOSEntities' section of the application configuration file.
        /// </summary>
        public CONTACTOSEntities() : base("name=CONTACTOSEntities", "CONTACTOSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new CONTACTOSEntities object.
        /// </summary>
        public CONTACTOSEntities(string connectionString) : base(connectionString, "CONTACTOSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new CONTACTOSEntities object.
        /// </summary>
        public CONTACTOSEntities(EntityConnection connection) : base(connection, "CONTACTOSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Colaborador> Colaborador
        {
            get
            {
                if ((_Colaborador == null))
                {
                    _Colaborador = base.CreateObjectSet<Colaborador>("Colaborador");
                }
                return _Colaborador;
            }
        }
        private ObjectSet<Colaborador> _Colaborador;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Colaborador EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToColaborador(Colaborador colaborador)
        {
            base.AddObject("Colaborador", colaborador);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CONTACTOSModel", Name="Colaborador")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Colaborador : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Colaborador object.
        /// </summary>
        /// <param name="nUM">Initial value of the NUM property.</param>
        /// <param name="id">Initial value of the ID property.</param>
        public static Colaborador CreateColaborador(global::System.Int32 nUM, global::System.Int32 id)
        {
            Colaborador colaborador = new Colaborador();
            colaborador.NUM = nUM;
            colaborador.ID = id;
            return colaborador;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 NUM
        {
            get
            {
                return _NUM;
            }
            set
            {
                if (_NUM != value)
                {
                    OnNUMChanging(value);
                    ReportPropertyChanging("NUM");
                    _NUM = StructuralObject.SetValidValue(value, "NUM");
                    ReportPropertyChanged("NUM");
                    OnNUMChanged();
                }
            }
        }
        private global::System.Int32 _NUM;
        partial void OnNUMChanging(global::System.Int32 value);
        partial void OnNUMChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EMPGRUPO
        {
            get
            {
                return _EMPGRUPO;
            }
            set
            {
                OnEMPGRUPOChanging(value);
                ReportPropertyChanging("EMPGRUPO");
                _EMPGRUPO = StructuralObject.SetValidValue(value, true, "EMPGRUPO");
                ReportPropertyChanged("EMPGRUPO");
                OnEMPGRUPOChanged();
            }
        }
        private global::System.String _EMPGRUPO;
        partial void OnEMPGRUPOChanging(global::System.String value);
        partial void OnEMPGRUPOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> NUMUNICO
        {
            get
            {
                return _NUMUNICO;
            }
            set
            {
                OnNUMUNICOChanging(value);
                ReportPropertyChanging("NUMUNICO");
                _NUMUNICO = StructuralObject.SetValidValue(value, "NUMUNICO");
                ReportPropertyChanged("NUMUNICO");
                OnNUMUNICOChanged();
            }
        }
        private Nullable<global::System.Int32> _NUMUNICO;
        partial void OnNUMUNICOChanging(Nullable<global::System.Int32> value);
        partial void OnNUMUNICOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TITULO
        {
            get
            {
                return _TITULO;
            }
            set
            {
                OnTITULOChanging(value);
                ReportPropertyChanging("TITULO");
                _TITULO = StructuralObject.SetValidValue(value, true, "TITULO");
                ReportPropertyChanged("TITULO");
                OnTITULOChanged();
            }
        }
        private global::System.String _TITULO;
        partial void OnTITULOChanging(global::System.String value);
        partial void OnTITULOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NOME
        {
            get
            {
                return _NOME;
            }
            set
            {
                OnNOMEChanging(value);
                ReportPropertyChanging("NOME");
                _NOME = StructuralObject.SetValidValue(value, true, "NOME");
                ReportPropertyChanged("NOME");
                OnNOMEChanged();
            }
        }
        private global::System.String _NOME;
        partial void OnNOMEChanging(global::System.String value);
        partial void OnNOMEChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> DATANASCIM
        {
            get
            {
                return _DATANASCIM;
            }
            set
            {
                OnDATANASCIMChanging(value);
                ReportPropertyChanging("DATANASCIM");
                _DATANASCIM = StructuralObject.SetValidValue(value, "DATANASCIM");
                ReportPropertyChanged("DATANASCIM");
                OnDATANASCIMChanged();
            }
        }
        private Nullable<global::System.Int32> _DATANASCIM;
        partial void OnDATANASCIMChanging(Nullable<global::System.Int32> value);
        partial void OnDATANASCIMChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> DATADMISSAO
        {
            get
            {
                return _DATADMISSAO;
            }
            set
            {
                OnDATADMISSAOChanging(value);
                ReportPropertyChanging("DATADMISSAO");
                _DATADMISSAO = StructuralObject.SetValidValue(value, "DATADMISSAO");
                ReportPropertyChanged("DATADMISSAO");
                OnDATADMISSAOChanged();
            }
        }
        private Nullable<global::System.Int32> _DATADMISSAO;
        partial void OnDATADMISSAOChanging(Nullable<global::System.Int32> value);
        partial void OnDATADMISSAOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CATEGORIA
        {
            get
            {
                return _CATEGORIA;
            }
            set
            {
                OnCATEGORIAChanging(value);
                ReportPropertyChanging("CATEGORIA");
                _CATEGORIA = StructuralObject.SetValidValue(value, true, "CATEGORIA");
                ReportPropertyChanged("CATEGORIA");
                OnCATEGORIAChanged();
            }
        }
        private global::System.String _CATEGORIA;
        partial void OnCATEGORIAChanging(global::System.String value);
        partial void OnCATEGORIAChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FUNCAO
        {
            get
            {
                return _FUNCAO;
            }
            set
            {
                OnFUNCAOChanging(value);
                ReportPropertyChanging("FUNCAO");
                _FUNCAO = StructuralObject.SetValidValue(value, true, "FUNCAO");
                ReportPropertyChanged("FUNCAO");
                OnFUNCAOChanged();
            }
        }
        private global::System.String _FUNCAO;
        partial void OnFUNCAOChanging(global::System.String value);
        partial void OnFUNCAOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CODUO
        {
            get
            {
                return _CODUO;
            }
            set
            {
                OnCODUOChanging(value);
                ReportPropertyChanging("CODUO");
                _CODUO = StructuralObject.SetValidValue(value, "CODUO");
                ReportPropertyChanged("CODUO");
                OnCODUOChanged();
            }
        }
        private Nullable<global::System.Int32> _CODUO;
        partial void OnCODUOChanging(Nullable<global::System.Int32> value);
        partial void OnCODUOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CODIGO_UO
        {
            get
            {
                return _CODIGO_UO;
            }
            set
            {
                OnCODIGO_UOChanging(value);
                ReportPropertyChanging("CODIGO_UO");
                _CODIGO_UO = StructuralObject.SetValidValue(value, true, "CODIGO_UO");
                ReportPropertyChanged("CODIGO_UO");
                OnCODIGO_UOChanged();
            }
        }
        private global::System.String _CODIGO_UO;
        partial void OnCODIGO_UOChanging(global::System.String value);
        partial void OnCODIGO_UOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DESCUO
        {
            get
            {
                return _DESCUO;
            }
            set
            {
                OnDESCUOChanging(value);
                ReportPropertyChanging("DESCUO");
                _DESCUO = StructuralObject.SetValidValue(value, true, "DESCUO");
                ReportPropertyChanged("DESCUO");
                OnDESCUOChanged();
            }
        }
        private global::System.String _DESCUO;
        partial void OnDESCUOChanging(global::System.String value);
        partial void OnDESCUOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value, "ID");
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FOTO
        {
            get
            {
                return _FOTO;
            }
            set
            {
                OnFOTOChanging(value);
                ReportPropertyChanging("FOTO");
                _FOTO = StructuralObject.SetValidValue(value, true, "FOTO");
                ReportPropertyChanged("FOTO");
                OnFOTOChanged();
            }
        }
        private global::System.String _FOTO;
        partial void OnFOTOChanging(global::System.String value);
        partial void OnFOTOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Username
        {
            get
            {
                return _Username;
            }
            set
            {
                OnUsernameChanging(value);
                ReportPropertyChanging("Username");
                _Username = StructuralObject.SetValidValue(value, true, "Username");
                ReportPropertyChanged("Username");
                OnUsernameChanged();
            }
        }
        private global::System.String _Username;
        partial void OnUsernameChanging(global::System.String value);
        partial void OnUsernameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String VCORP
        {
            get
            {
                return _VCORP;
            }
            set
            {
                OnVCORPChanging(value);
                ReportPropertyChanging("VCORP");
                _VCORP = StructuralObject.SetValidValue(value, true, "VCORP");
                ReportPropertyChanged("VCORP");
                OnVCORPChanged();
            }
        }
        private global::System.String _VCORP;
        partial void OnVCORPChanging(global::System.String value);
        partial void OnVCORPChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MORADA
        {
            get
            {
                return _MORADA;
            }
            set
            {
                OnMORADAChanging(value);
                ReportPropertyChanging("MORADA");
                _MORADA = StructuralObject.SetValidValue(value, true, "MORADA");
                ReportPropertyChanged("MORADA");
                OnMORADAChanged();
            }
        }
        private global::System.String _MORADA;
        partial void OnMORADAChanging(global::System.String value);
        partial void OnMORADAChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LOCALIDADE
        {
            get
            {
                return _LOCALIDADE;
            }
            set
            {
                OnLOCALIDADEChanging(value);
                ReportPropertyChanging("LOCALIDADE");
                _LOCALIDADE = StructuralObject.SetValidValue(value, true, "LOCALIDADE");
                ReportPropertyChanged("LOCALIDADE");
                OnLOCALIDADEChanged();
            }
        }
        private global::System.String _LOCALIDADE;
        partial void OnLOCALIDADEChanging(global::System.String value);
        partial void OnLOCALIDADEChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CODPOSTAL
        {
            get
            {
                return _CODPOSTAL;
            }
            set
            {
                OnCODPOSTALChanging(value);
                ReportPropertyChanging("CODPOSTAL");
                _CODPOSTAL = StructuralObject.SetValidValue(value, true, "CODPOSTAL");
                ReportPropertyChanged("CODPOSTAL");
                OnCODPOSTALChanged();
            }
        }
        private global::System.String _CODPOSTAL;
        partial void OnCODPOSTALChanging(global::System.String value);
        partial void OnCODPOSTALChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TELGERAL
        {
            get
            {
                return _TELGERAL;
            }
            set
            {
                OnTELGERALChanging(value);
                ReportPropertyChanging("TELGERAL");
                _TELGERAL = StructuralObject.SetValidValue(value, true, "TELGERAL");
                ReportPropertyChanged("TELGERAL");
                OnTELGERALChanged();
            }
        }
        private global::System.String _TELGERAL;
        partial void OnTELGERALChanging(global::System.String value);
        partial void OnTELGERALChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FAX
        {
            get
            {
                return _FAX;
            }
            set
            {
                OnFAXChanging(value);
                ReportPropertyChanging("FAX");
                _FAX = StructuralObject.SetValidValue(value, true, "FAX");
                ReportPropertyChanged("FAX");
                OnFAXChanged();
            }
        }
        private global::System.String _FAX;
        partial void OnFAXChanging(global::System.String value);
        partial void OnFAXChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TELDIRECTO
        {
            get
            {
                return _TELDIRECTO;
            }
            set
            {
                OnTELDIRECTOChanging(value);
                ReportPropertyChanging("TELDIRECTO");
                _TELDIRECTO = StructuralObject.SetValidValue(value, true, "TELDIRECTO");
                ReportPropertyChanged("TELDIRECTO");
                OnTELDIRECTOChanged();
            }
        }
        private global::System.String _TELDIRECTO;
        partial void OnTELDIRECTOChanging(global::System.String value);
        partial void OnTELDIRECTOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EXTENSAO
        {
            get
            {
                return _EXTENSAO;
            }
            set
            {
                OnEXTENSAOChanging(value);
                ReportPropertyChanging("EXTENSAO");
                _EXTENSAO = StructuralObject.SetValidValue(value, true, "EXTENSAO");
                ReportPropertyChanged("EXTENSAO");
                OnEXTENSAOChanged();
            }
        }
        private global::System.String _EXTENSAO;
        partial void OnEXTENSAOChanging(global::System.String value);
        partial void OnEXTENSAOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CELULAR
        {
            get
            {
                return _CELULAR;
            }
            set
            {
                OnCELULARChanging(value);
                ReportPropertyChanging("CELULAR");
                _CELULAR = StructuralObject.SetValidValue(value, true, "CELULAR");
                ReportPropertyChanged("CELULAR");
                OnCELULARChanged();
            }
        }
        private global::System.String _CELULAR;
        partial void OnCELULARChanging(global::System.String value);
        partial void OnCELULARChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EMAIL
        {
            get
            {
                return _EMAIL;
            }
            set
            {
                OnEMAILChanging(value);
                ReportPropertyChanging("EMAIL");
                _EMAIL = StructuralObject.SetValidValue(value, true, "EMAIL");
                ReportPropertyChanged("EMAIL");
                OnEMAILChanged();
            }
        }
        private global::System.String _EMAIL;
        partial void OnEMAILChanging(global::System.String value);
        partial void OnEMAILChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> AVALIADOR
        {
            get
            {
                return _AVALIADOR;
            }
            set
            {
                OnAVALIADORChanging(value);
                ReportPropertyChanging("AVALIADOR");
                _AVALIADOR = StructuralObject.SetValidValue(value, "AVALIADOR");
                ReportPropertyChanged("AVALIADOR");
                OnAVALIADORChanged();
            }
        }
        private Nullable<global::System.Int32> _AVALIADOR;
        partial void OnAVALIADORChanging(Nullable<global::System.Int32> value);
        partial void OnAVALIADORChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PASSWORD
        {
            get
            {
                return _PASSWORD;
            }
            set
            {
                OnPASSWORDChanging(value);
                ReportPropertyChanging("PASSWORD");
                _PASSWORD = StructuralObject.SetValidValue(value, true, "PASSWORD");
                ReportPropertyChanged("PASSWORD");
                OnPASSWORDChanged();
            }
        }
        private global::System.String _PASSWORD;
        partial void OnPASSWORDChanging(global::System.String value);
        partial void OnPASSWORDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telcasa
        {
            get
            {
                return _Telcasa;
            }
            set
            {
                OnTelcasaChanging(value);
                ReportPropertyChanging("Telcasa");
                _Telcasa = StructuralObject.SetValidValue(value, true, "Telcasa");
                ReportPropertyChanged("Telcasa");
                OnTelcasaChanged();
            }
        }
        private global::System.String _Telcasa;
        partial void OnTelcasaChanging(global::System.String value);
        partial void OnTelcasaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Tipoassina
        {
            get
            {
                return _Tipoassina;
            }
            set
            {
                OnTipoassinaChanging(value);
                ReportPropertyChanging("Tipoassina");
                _Tipoassina = StructuralObject.SetValidValue(value, true, "Tipoassina");
                ReportPropertyChanged("Tipoassina");
                OnTipoassinaChanged();
            }
        }
        private global::System.String _Tipoassina;
        partial void OnTipoassinaChanging(global::System.String value);
        partial void OnTipoassinaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Assina
        {
            get
            {
                return _Assina;
            }
            set
            {
                OnAssinaChanging(value);
                ReportPropertyChanging("Assina");
                _Assina = StructuralObject.SetValidValue(value, true, "Assina");
                ReportPropertyChanged("Assina");
                OnAssinaChanged();
            }
        }
        private global::System.String _Assina;
        partial void OnAssinaChanging(global::System.String value);
        partial void OnAssinaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Byte> TIPO_AVALIACAO
        {
            get
            {
                return _TIPO_AVALIACAO;
            }
            set
            {
                OnTIPO_AVALIACAOChanging(value);
                ReportPropertyChanging("TIPO_AVALIACAO");
                _TIPO_AVALIACAO = StructuralObject.SetValidValue(value, "TIPO_AVALIACAO");
                ReportPropertyChanged("TIPO_AVALIACAO");
                OnTIPO_AVALIACAOChanged();
            }
        }
        private Nullable<global::System.Byte> _TIPO_AVALIACAO;
        partial void OnTIPO_AVALIACAOChanging(Nullable<global::System.Byte> value);
        partial void OnTIPO_AVALIACAOChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> PASS
        {
            get
            {
                return _PASS;
            }
            set
            {
                OnPASSChanging(value);
                ReportPropertyChanging("PASS");
                _PASS = StructuralObject.SetValidValue(value, "PASS");
                ReportPropertyChanged("PASS");
                OnPASSChanged();
            }
        }
        private Nullable<global::System.Boolean> _PASS;
        partial void OnPASSChanging(Nullable<global::System.Boolean> value);
        partial void OnPASSChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NIVEL
        {
            get
            {
                return _NIVEL;
            }
            set
            {
                OnNIVELChanging(value);
                ReportPropertyChanging("NIVEL");
                _NIVEL = StructuralObject.SetValidValue(value, true, "NIVEL");
                ReportPropertyChanged("NIVEL");
                OnNIVELChanged();
            }
        }
        private global::System.String _NIVEL;
        partial void OnNIVELChanging(global::System.String value);
        partial void OnNIVELChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HABILITACOES
        {
            get
            {
                return _HABILITACOES;
            }
            set
            {
                OnHABILITACOESChanging(value);
                ReportPropertyChanging("HABILITACOES");
                _HABILITACOES = StructuralObject.SetValidValue(value, true, "HABILITACOES");
                ReportPropertyChanged("HABILITACOES");
                OnHABILITACOESChanged();
            }
        }
        private global::System.String _HABILITACOES;
        partial void OnHABILITACOESChanging(global::System.String value);
        partial void OnHABILITACOESChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SITCONT
        {
            get
            {
                return _SITCONT;
            }
            set
            {
                OnSITCONTChanging(value);
                ReportPropertyChanging("SITCONT");
                _SITCONT = StructuralObject.SetValidValue(value, true, "SITCONT");
                ReportPropertyChanged("SITCONT");
                OnSITCONTChanged();
            }
        }
        private global::System.String _SITCONT;
        partial void OnSITCONTChanging(global::System.String value);
        partial void OnSITCONTChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NUIT
        {
            get
            {
                return _NUIT;
            }
            set
            {
                OnNUITChanging(value);
                ReportPropertyChanging("NUIT");
                _NUIT = StructuralObject.SetValidValue(value, true, "NUIT");
                ReportPropertyChanged("NUIT");
                OnNUITChanged();
            }
        }
        private global::System.String _NUIT;
        partial void OnNUITChanging(global::System.String value);
        partial void OnNUITChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NOMEABREV
        {
            get
            {
                return _NOMEABREV;
            }
            set
            {
                OnNOMEABREVChanging(value);
                ReportPropertyChanging("NOMEABREV");
                _NOMEABREV = StructuralObject.SetValidValue(value, true, "NOMEABREV");
                ReportPropertyChanged("NOMEABREV");
                OnNOMEABREVChanged();
            }
        }
        private global::System.String _NOMEABREV;
        partial void OnNOMEABREVChanging(global::System.String value);
        partial void OnNOMEABREVChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String UserALT
        {
            get
            {
                return _UserALT;
            }
            set
            {
                OnUserALTChanging(value);
                ReportPropertyChanging("UserALT");
                _UserALT = StructuralObject.SetValidValue(value, true, "UserALT");
                ReportPropertyChanged("UserALT");
                OnUserALTChanged();
            }
        }
        private global::System.String _UserALT;
        partial void OnUserALTChanging(global::System.String value);
        partial void OnUserALTChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DataALT
        {
            get
            {
                return _DataALT;
            }
            set
            {
                OnDataALTChanging(value);
                ReportPropertyChanging("DataALT");
                _DataALT = StructuralObject.SetValidValue(value, true, "DataALT");
                ReportPropertyChanged("DataALT");
                OnDataALTChanged();
            }
        }
        private global::System.String _DataALT;
        partial void OnDataALTChanging(global::System.String value);
        partial void OnDataALTChanged();

        #endregion

    }

    #endregion

}
