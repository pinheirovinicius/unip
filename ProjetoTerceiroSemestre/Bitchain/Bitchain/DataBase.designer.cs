#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bitchain
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="db_Bitchain")]
	public partial class DataBaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    partial void InsertPerfil(Perfil instance);
    partial void UpdatePerfil(Perfil instance);
    partial void DeletePerfil(Perfil instance);
    partial void InsertUsuarioLogado(UsuarioLogado instance);
    partial void UpdateUsuarioLogado(UsuarioLogado instance);
    partial void DeleteUsuarioLogado(UsuarioLogado instance);
    partial void InsertListaMoeda(ListaMoeda instance);
    partial void UpdateListaMoeda(ListaMoeda instance);
    partial void DeleteListaMoeda(ListaMoeda instance);
    #endregion
		
		public DataBaseDataContext() : 
				base(global::Bitchain.Properties.Settings.Default.db_BitchainConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
		
		public System.Data.Linq.Table<Perfil> Perfils
		{
			get
			{
				return this.GetTable<Perfil>();
			}
		}
		
		public System.Data.Linq.Table<UsuarioLogado> UsuarioLogados
		{
			get
			{
				return this.GetTable<UsuarioLogado>();
			}
		}
		
		public System.Data.Linq.Table<ListaMoeda> ListaMoedas
		{
			get
			{
				return this.GetTable<ListaMoeda>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_USUARIO;
		
		private string _NM_NOME;
		
		private string _NR_CPF;
		
		private string _NM_EMAIL;
		
		private string _NR_TELEFONE;
		
		private string _NR_CELULAR;
		
		private string _NM_LOGIN;
		
		private string _NM_SENHA;
		
		private System.Nullable<int> _ID_PERFIL;
		
		private System.Nullable<byte> _FL_HABILITA;
		
		private System.Nullable<byte> _FL_TROCA_SENHA;
		
		private string _NM_USUARIO_CADASTRO;
		
		private System.Nullable<System.DateTime> _DT_CADASTRO;
		
		private string _NM_USUARIO_ALTERACAO;
		
		private System.Nullable<System.DateTime> _DT_ALTERACAO;
		
		private System.Nullable<int> _NR_ULTIMO_ACESSO;
		
		private System.Nullable<System.DateTime> _DT_ULTIMO_ACESSO;
		
		private EntityRef<Perfil> _Perfil;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_USUARIOChanging(int value);
    partial void OnID_USUARIOChanged();
    partial void OnNM_NOMEChanging(string value);
    partial void OnNM_NOMEChanged();
    partial void OnNR_CPFChanging(string value);
    partial void OnNR_CPFChanged();
    partial void OnNM_EMAILChanging(string value);
    partial void OnNM_EMAILChanged();
    partial void OnNR_TELEFONEChanging(string value);
    partial void OnNR_TELEFONEChanged();
    partial void OnNR_CELULARChanging(string value);
    partial void OnNR_CELULARChanged();
    partial void OnNM_LOGINChanging(string value);
    partial void OnNM_LOGINChanged();
    partial void OnNM_SENHAChanging(string value);
    partial void OnNM_SENHAChanged();
    partial void OnID_PERFILChanging(System.Nullable<int> value);
    partial void OnID_PERFILChanged();
    partial void OnFL_HABILITAChanging(System.Nullable<byte> value);
    partial void OnFL_HABILITAChanged();
    partial void OnFL_TROCA_SENHAChanging(System.Nullable<byte> value);
    partial void OnFL_TROCA_SENHAChanged();
    partial void OnNM_USUARIO_CADASTROChanging(string value);
    partial void OnNM_USUARIO_CADASTROChanged();
    partial void OnDT_CADASTROChanging(System.Nullable<System.DateTime> value);
    partial void OnDT_CADASTROChanged();
    partial void OnNM_USUARIO_ALTERACAOChanging(string value);
    partial void OnNM_USUARIO_ALTERACAOChanged();
    partial void OnDT_ALTERACAOChanging(System.Nullable<System.DateTime> value);
    partial void OnDT_ALTERACAOChanged();
    partial void OnNR_ULTIMO_ACESSOChanging(System.Nullable<int> value);
    partial void OnNR_ULTIMO_ACESSOChanged();
    partial void OnDT_ULTIMO_ACESSOChanging(System.Nullable<System.DateTime> value);
    partial void OnDT_ULTIMO_ACESSOChanged();
    #endregion
		
		public Usuario()
		{
			this._Perfil = default(EntityRef<Perfil>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_USUARIO", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID_USUARIO
		{
			get
			{
				return this._ID_USUARIO;
			}
			set
			{
				if ((this._ID_USUARIO != value))
				{
					this.OnID_USUARIOChanging(value);
					this.SendPropertyChanging();
					this._ID_USUARIO = value;
					this.SendPropertyChanged("ID_USUARIO");
					this.OnID_USUARIOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_NOME", DbType="VarChar(100)")]
		public string NM_NOME
		{
			get
			{
				return this._NM_NOME;
			}
			set
			{
				if ((this._NM_NOME != value))
				{
					this.OnNM_NOMEChanging(value);
					this.SendPropertyChanging();
					this._NM_NOME = value;
					this.SendPropertyChanged("NM_NOME");
					this.OnNM_NOMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NR_CPF", DbType="VarChar(14)")]
		public string NR_CPF
		{
			get
			{
				return this._NR_CPF;
			}
			set
			{
				if ((this._NR_CPF != value))
				{
					this.OnNR_CPFChanging(value);
					this.SendPropertyChanging();
					this._NR_CPF = value;
					this.SendPropertyChanged("NR_CPF");
					this.OnNR_CPFChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_EMAIL", DbType="VarChar(100)")]
		public string NM_EMAIL
		{
			get
			{
				return this._NM_EMAIL;
			}
			set
			{
				if ((this._NM_EMAIL != value))
				{
					this.OnNM_EMAILChanging(value);
					this.SendPropertyChanging();
					this._NM_EMAIL = value;
					this.SendPropertyChanged("NM_EMAIL");
					this.OnNM_EMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NR_TELEFONE", DbType="VarChar(25)")]
		public string NR_TELEFONE
		{
			get
			{
				return this._NR_TELEFONE;
			}
			set
			{
				if ((this._NR_TELEFONE != value))
				{
					this.OnNR_TELEFONEChanging(value);
					this.SendPropertyChanging();
					this._NR_TELEFONE = value;
					this.SendPropertyChanged("NR_TELEFONE");
					this.OnNR_TELEFONEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NR_CELULAR", DbType="VarChar(25)")]
		public string NR_CELULAR
		{
			get
			{
				return this._NR_CELULAR;
			}
			set
			{
				if ((this._NR_CELULAR != value))
				{
					this.OnNR_CELULARChanging(value);
					this.SendPropertyChanging();
					this._NR_CELULAR = value;
					this.SendPropertyChanged("NR_CELULAR");
					this.OnNR_CELULARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_LOGIN", DbType="VarChar(50)")]
		public string NM_LOGIN
		{
			get
			{
				return this._NM_LOGIN;
			}
			set
			{
				if ((this._NM_LOGIN != value))
				{
					this.OnNM_LOGINChanging(value);
					this.SendPropertyChanging();
					this._NM_LOGIN = value;
					this.SendPropertyChanged("NM_LOGIN");
					this.OnNM_LOGINChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_SENHA", DbType="VarChar(10)")]
		public string NM_SENHA
		{
			get
			{
				return this._NM_SENHA;
			}
			set
			{
				if ((this._NM_SENHA != value))
				{
					this.OnNM_SENHAChanging(value);
					this.SendPropertyChanging();
					this._NM_SENHA = value;
					this.SendPropertyChanged("NM_SENHA");
					this.OnNM_SENHAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_PERFIL", DbType="Int")]
		public System.Nullable<int> ID_PERFIL
		{
			get
			{
				return this._ID_PERFIL;
			}
			set
			{
				if ((this._ID_PERFIL != value))
				{
					if (this._Perfil.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_PERFILChanging(value);
					this.SendPropertyChanging();
					this._ID_PERFIL = value;
					this.SendPropertyChanged("ID_PERFIL");
					this.OnID_PERFILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FL_HABILITA", DbType="TinyInt")]
		public System.Nullable<byte> FL_HABILITA
		{
			get
			{
				return this._FL_HABILITA;
			}
			set
			{
				if ((this._FL_HABILITA != value))
				{
					this.OnFL_HABILITAChanging(value);
					this.SendPropertyChanging();
					this._FL_HABILITA = value;
					this.SendPropertyChanged("FL_HABILITA");
					this.OnFL_HABILITAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FL_TROCA_SENHA", DbType="TinyInt")]
		public System.Nullable<byte> FL_TROCA_SENHA
		{
			get
			{
				return this._FL_TROCA_SENHA;
			}
			set
			{
				if ((this._FL_TROCA_SENHA != value))
				{
					this.OnFL_TROCA_SENHAChanging(value);
					this.SendPropertyChanging();
					this._FL_TROCA_SENHA = value;
					this.SendPropertyChanged("FL_TROCA_SENHA");
					this.OnFL_TROCA_SENHAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_USUARIO_CADASTRO", DbType="VarChar(50)")]
		public string NM_USUARIO_CADASTRO
		{
			get
			{
				return this._NM_USUARIO_CADASTRO;
			}
			set
			{
				if ((this._NM_USUARIO_CADASTRO != value))
				{
					this.OnNM_USUARIO_CADASTROChanging(value);
					this.SendPropertyChanging();
					this._NM_USUARIO_CADASTRO = value;
					this.SendPropertyChanged("NM_USUARIO_CADASTRO");
					this.OnNM_USUARIO_CADASTROChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DT_CADASTRO", DbType="DateTime")]
		public System.Nullable<System.DateTime> DT_CADASTRO
		{
			get
			{
				return this._DT_CADASTRO;
			}
			set
			{
				if ((this._DT_CADASTRO != value))
				{
					this.OnDT_CADASTROChanging(value);
					this.SendPropertyChanging();
					this._DT_CADASTRO = value;
					this.SendPropertyChanged("DT_CADASTRO");
					this.OnDT_CADASTROChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_USUARIO_ALTERACAO", DbType="VarChar(50)")]
		public string NM_USUARIO_ALTERACAO
		{
			get
			{
				return this._NM_USUARIO_ALTERACAO;
			}
			set
			{
				if ((this._NM_USUARIO_ALTERACAO != value))
				{
					this.OnNM_USUARIO_ALTERACAOChanging(value);
					this.SendPropertyChanging();
					this._NM_USUARIO_ALTERACAO = value;
					this.SendPropertyChanged("NM_USUARIO_ALTERACAO");
					this.OnNM_USUARIO_ALTERACAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DT_ALTERACAO", DbType="DateTime")]
		public System.Nullable<System.DateTime> DT_ALTERACAO
		{
			get
			{
				return this._DT_ALTERACAO;
			}
			set
			{
				if ((this._DT_ALTERACAO != value))
				{
					this.OnDT_ALTERACAOChanging(value);
					this.SendPropertyChanging();
					this._DT_ALTERACAO = value;
					this.SendPropertyChanged("DT_ALTERACAO");
					this.OnDT_ALTERACAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NR_ULTIMO_ACESSO", DbType="Int")]
		public System.Nullable<int> NR_ULTIMO_ACESSO
		{
			get
			{
				return this._NR_ULTIMO_ACESSO;
			}
			set
			{
				if ((this._NR_ULTIMO_ACESSO != value))
				{
					this.OnNR_ULTIMO_ACESSOChanging(value);
					this.SendPropertyChanging();
					this._NR_ULTIMO_ACESSO = value;
					this.SendPropertyChanged("NR_ULTIMO_ACESSO");
					this.OnNR_ULTIMO_ACESSOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DT_ULTIMO_ACESSO", DbType="DateTime")]
		public System.Nullable<System.DateTime> DT_ULTIMO_ACESSO
		{
			get
			{
				return this._DT_ULTIMO_ACESSO;
			}
			set
			{
				if ((this._DT_ULTIMO_ACESSO != value))
				{
					this.OnDT_ULTIMO_ACESSOChanging(value);
					this.SendPropertyChanging();
					this._DT_ULTIMO_ACESSO = value;
					this.SendPropertyChanged("DT_ULTIMO_ACESSO");
					this.OnDT_ULTIMO_ACESSOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Perfil_Usuario", Storage="_Perfil", ThisKey="ID_PERFIL", OtherKey="ID_PERFIL", IsForeignKey=true)]
		public Perfil Perfil
		{
			get
			{
				return this._Perfil.Entity;
			}
			set
			{
				Perfil previousValue = this._Perfil.Entity;
				if (((previousValue != value) 
							|| (this._Perfil.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Perfil.Entity = null;
						previousValue.Usuarios.Remove(this);
					}
					this._Perfil.Entity = value;
					if ((value != null))
					{
						value.Usuarios.Add(this);
						this._ID_PERFIL = value.ID_PERFIL;
					}
					else
					{
						this._ID_PERFIL = default(Nullable<int>);
					}
					this.SendPropertyChanged("Perfil");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Perfil")]
	public partial class Perfil : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_PERFIL;
		
		private string _NM_DESCRICAO;
		
		private EntitySet<Usuario> _Usuarios;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_PERFILChanging(int value);
    partial void OnID_PERFILChanged();
    partial void OnNM_DESCRICAOChanging(string value);
    partial void OnNM_DESCRICAOChanged();
    #endregion
		
		public Perfil()
		{
			this._Usuarios = new EntitySet<Usuario>(new Action<Usuario>(this.attach_Usuarios), new Action<Usuario>(this.detach_Usuarios));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_PERFIL", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID_PERFIL
		{
			get
			{
				return this._ID_PERFIL;
			}
			set
			{
				if ((this._ID_PERFIL != value))
				{
					this.OnID_PERFILChanging(value);
					this.SendPropertyChanging();
					this._ID_PERFIL = value;
					this.SendPropertyChanged("ID_PERFIL");
					this.OnID_PERFILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_DESCRICAO", DbType="VarChar(60) NOT NULL", CanBeNull=false)]
		public string NM_DESCRICAO
		{
			get
			{
				return this._NM_DESCRICAO;
			}
			set
			{
				if ((this._NM_DESCRICAO != value))
				{
					this.OnNM_DESCRICAOChanging(value);
					this.SendPropertyChanging();
					this._NM_DESCRICAO = value;
					this.SendPropertyChanged("NM_DESCRICAO");
					this.OnNM_DESCRICAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Perfil_Usuario", Storage="_Usuarios", ThisKey="ID_PERFIL", OtherKey="ID_PERFIL")]
		public EntitySet<Usuario> Usuarios
		{
			get
			{
				return this._Usuarios;
			}
			set
			{
				this._Usuarios.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Usuarios(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.Perfil = this;
		}
		
		private void detach_Usuarios(Usuario entity)
		{
			this.SendPropertyChanging();
			entity.Perfil = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UsuarioLogado")]
	public partial class UsuarioLogado : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_USUARIOLOGADO;
		
		private System.Nullable<int> _ID_USUARIO;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_USUARIOLOGADOChanging(int value);
    partial void OnID_USUARIOLOGADOChanged();
    partial void OnID_USUARIOChanging(System.Nullable<int> value);
    partial void OnID_USUARIOChanged();
    #endregion
		
		public UsuarioLogado()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_USUARIOLOGADO", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID_USUARIOLOGADO
		{
			get
			{
				return this._ID_USUARIOLOGADO;
			}
			set
			{
				if ((this._ID_USUARIOLOGADO != value))
				{
					this.OnID_USUARIOLOGADOChanging(value);
					this.SendPropertyChanging();
					this._ID_USUARIOLOGADO = value;
					this.SendPropertyChanged("ID_USUARIOLOGADO");
					this.OnID_USUARIOLOGADOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_USUARIO", DbType="Int")]
		public System.Nullable<int> ID_USUARIO
		{
			get
			{
				return this._ID_USUARIO;
			}
			set
			{
				if ((this._ID_USUARIO != value))
				{
					this.OnID_USUARIOChanging(value);
					this.SendPropertyChanging();
					this._ID_USUARIO = value;
					this.SendPropertyChanged("ID_USUARIO");
					this.OnID_USUARIOChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ListaMoeda")]
	public partial class ListaMoeda : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_MOEDA;
		
		private string _NM_SIGLA;
		
		private string _NM_DESCRICAO;
		
		private System.Nullable<decimal> _VL_BASE;
		
		private System.Nullable<decimal> _VL_REAL;
		
		private System.Nullable<byte> _FL_HABILITA;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_MOEDAChanging(int value);
    partial void OnID_MOEDAChanged();
    partial void OnNM_SIGLAChanging(string value);
    partial void OnNM_SIGLAChanged();
    partial void OnNM_DESCRICAOChanging(string value);
    partial void OnNM_DESCRICAOChanged();
    partial void OnVL_BASEChanging(System.Nullable<decimal> value);
    partial void OnVL_BASEChanged();
    partial void OnVL_REALChanging(System.Nullable<decimal> value);
    partial void OnVL_REALChanged();
    partial void OnFL_HABILITAChanging(System.Nullable<byte> value);
    partial void OnFL_HABILITAChanged();
    #endregion
		
		public ListaMoeda()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_MOEDA", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID_MOEDA
		{
			get
			{
				return this._ID_MOEDA;
			}
			set
			{
				if ((this._ID_MOEDA != value))
				{
					this.OnID_MOEDAChanging(value);
					this.SendPropertyChanging();
					this._ID_MOEDA = value;
					this.SendPropertyChanged("ID_MOEDA");
					this.OnID_MOEDAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_SIGLA", DbType="VarChar(5)")]
		public string NM_SIGLA
		{
			get
			{
				return this._NM_SIGLA;
			}
			set
			{
				if ((this._NM_SIGLA != value))
				{
					this.OnNM_SIGLAChanging(value);
					this.SendPropertyChanging();
					this._NM_SIGLA = value;
					this.SendPropertyChanged("NM_SIGLA");
					this.OnNM_SIGLAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NM_DESCRICAO", DbType="VarChar(50)")]
		public string NM_DESCRICAO
		{
			get
			{
				return this._NM_DESCRICAO;
			}
			set
			{
				if ((this._NM_DESCRICAO != value))
				{
					this.OnNM_DESCRICAOChanging(value);
					this.SendPropertyChanging();
					this._NM_DESCRICAO = value;
					this.SendPropertyChanged("NM_DESCRICAO");
					this.OnNM_DESCRICAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VL_BASE", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> VL_BASE
		{
			get
			{
				return this._VL_BASE;
			}
			set
			{
				if ((this._VL_BASE != value))
				{
					this.OnVL_BASEChanging(value);
					this.SendPropertyChanging();
					this._VL_BASE = value;
					this.SendPropertyChanged("VL_BASE");
					this.OnVL_BASEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VL_REAL", DbType="Decimal(20,2)")]
		public System.Nullable<decimal> VL_REAL
		{
			get
			{
				return this._VL_REAL;
			}
			set
			{
				if ((this._VL_REAL != value))
				{
					this.OnVL_REALChanging(value);
					this.SendPropertyChanging();
					this._VL_REAL = value;
					this.SendPropertyChanged("VL_REAL");
					this.OnVL_REALChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FL_HABILITA", DbType="TinyInt")]
		public System.Nullable<byte> FL_HABILITA
		{
			get
			{
				return this._FL_HABILITA;
			}
			set
			{
				if ((this._FL_HABILITA != value))
				{
					this.OnFL_HABILITAChanging(value);
					this.SendPropertyChanging();
					this._FL_HABILITA = value;
					this.SendPropertyChanged("FL_HABILITA");
					this.OnFL_HABILITAChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
