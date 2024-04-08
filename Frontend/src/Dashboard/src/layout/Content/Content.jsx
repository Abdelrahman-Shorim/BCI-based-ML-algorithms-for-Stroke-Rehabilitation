import "./Content.css";
import ContentTop from '../../components/ContentTop/ContentTop';
import ContentMain from '../../components/ContentMain/ContentMain';

const Content = ({role}) => {
  return (
    <div className='main-content'>
      <ContentTop />
      <ContentMain role={role} />
    </div>
  )
}

export default Content
